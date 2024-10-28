using BSMSShared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSMSShared.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Author> DeleteAuthorAsync(Author author);
    }
}
