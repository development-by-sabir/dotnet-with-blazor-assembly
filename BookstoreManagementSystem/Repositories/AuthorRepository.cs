using BookstoreManagementSystem.Data;
using BSMSShared.Interfaces;
using BSMSShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreManagementSystem.Repositories
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly BookstoreDbContext _context;

        public AuthorRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var res = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return res;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var result = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var result = _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Author> DeleteAuthorAsync(Author author)
        {
            var result = _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
