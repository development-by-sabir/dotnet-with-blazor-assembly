using BSMSShared.InputTypes;
using BSMSShared.Interfaces;
using BSMSShared.Models;

namespace BookstoreManagementSystem.GraphQL
{
    public class Mutations
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public Mutations(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        #region Book Mutation

        public async Task<Book> AddBookAsync(BookInput book)
        {
            var _book = new Book
            {
                Title = book.Title,
                Price = book.Price,
                AuthorId = book.AuthorId
            };
            return await _bookRepository.AddBookAsync(_book);
        }

        public async Task<Book> UpdateBookAsync(BookInput book)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Price = book.Price;
                existingBook.AuthorId = book.AuthorId;
                return await _bookRepository.UpdateBookAsync(existingBook);
            }
            return existingBook;
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook != null)
                return await _bookRepository.DeleteBookAsync(existingBook);
            return existingBook;
        }

        #endregion


        #region Author Mutation

        public async Task<Author> AddAuthorAsync(AuthorInput author)
        {
            var _author = new Author { Name = author.Name };
            return await _authorRepository.AddAuthorAsync(_author);
        }

        public async Task<Author> UpdateAuthorAsync(AuthorInput author)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                return await _authorRepository.UpdateAuthorAsync(existingAuthor);
            }
            return existingAuthor;
        }

        public async Task<Author> DeleteAuthorAsync(int id)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);
            if (existingAuthor != null)
                return await _authorRepository.DeleteAuthorAsync(existingAuthor);
            return existingAuthor;
        }

        #endregion
    }
}
