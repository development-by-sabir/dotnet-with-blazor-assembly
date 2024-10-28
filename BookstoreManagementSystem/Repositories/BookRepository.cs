using BookstoreManagementSystem.Data;
using BookstoreManagementSystem.GraphQL;
using BSMSShared.Interfaces;
using BSMSShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreManagementSystem.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookstoreDbContext _context;
        private readonly ILogger<BookRepository> _logger;


        public BookRepository(ILogger<BookRepository> logger, BookstoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                return await _context.Books.Include(b => b.Author).ToListAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Exception occurred while getting books");
                return null;
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {
                return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Exception occurred while getting book against id: {id}");
                return null;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var result  = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var result = _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            var result = _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
