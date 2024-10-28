using GraphQL.Client.Http;
using GraphQL;
using BSMSShared.DTO;
using BSMSShared.Models;
using Newtonsoft.Json;
using System.Xml.Linq;
using BSMSClient.Pages;

namespace BSMSClient.Services
{
    public class BookStoreGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public BookStoreGraphQLService(GraphQLHttpClient client)
        {
            _client = client;
        }

        #region Books GraphsQL Service

        public async Task<List<BookDto>> GetBooksAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query {
                        books {
                            id
                            title
                            price
                            authorId
                            author {
                                id
                                name
                            }
                        }
                    }"
            };

            var response = await _client.SendQueryAsync<BooksQueryResponse>(query);
            return response.Data.Books;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query($id: Int!) {
                        bookById(id: $id) { 
                            id
                            title
                            price
                            authorId
                            author {
                              name
                            }
                        }
                    }",
                Variables = new { id }
            };

            var response = await _client.SendQueryAsync<BookByIdQueryResponse>(query);
            return response.Data.BookById;
        }

        public async Task AddBookAsync(BookDto book)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($book: BookInput!) {
                        addBook(book: $book) {
                            id
                            title
                            price
                            authorId
                        }
                    }",
                Variables = new
                {
                    book = new
                    {
                        id = book.Id,
                        title = book.Title,
                        price = book.Price,
                        authorId = book.AuthorId
                    }
                }
            };

            await _client.SendMutationAsync<BookQueryResponse>(mutation);
        }

        public async Task UpdateBookAsync(BookDto book)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($book: BookInput!) {
                        updateBook(book: $book) {
                            id
                            title
                            price
                            authorId
                        }
                    }",
                Variables = new
                {
                    book = new
                    {
                        id = book.Id,
                        title = book.Title,
                        price = book.Price,
                        authorId = book.AuthorId
                    }
                }
            };

            await _client.SendMutationAsync<BookQueryResponse>(mutation);
        }

        public async Task DeleteBookAsync(int id)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($id: Int!) {
                        deleteBook(id: $id) {
                            id
                        }
                    }",
                Variables = new { id }
            };

            await _client.SendMutationAsync<BookQueryResponse>(mutation);
        }

        #endregion



        #region Authors GraphQL Service

        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query {
                        authors {
                            id
                            name
                        }
                    }"
            };

            var response = await _client.SendQueryAsync<AuthorsQueryReponse>(query);
            return response.Data.Authors;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query($id: Int!) {
                        authorById(id: $id) { 
                            id
                            name
                        }
                    }",
                Variables = new { id }
            };

            var response = await _client.SendQueryAsync<AuthorByIdQueryReponse>(query);
            return response.Data.AuthorById;
        }

        public async Task AddAuthorAsync(AuthorDto author)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($author: AuthorInput!) {
                        addAuthor(author: $author) {
                            id
                            name
                        }
                    }",
                Variables = new
                {
                    author = new
                    {
                        id = author.Id,
                        name = author.Name
                    }
                }
            };

            await _client.SendMutationAsync<AuthorQueryReponse>(mutation);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($id: Int!) {
                        deleteAuthor(id: $id) {
                            id
                        }
                    }",
                Variables = new { id }
            };

            await _client.SendMutationAsync<AuthorQueryReponse>(mutation);
        }

        public async Task UpdateAuthorAsync(AuthorDto author)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation($author: AuthorInput!) {
                        updateAuthor(author: $author) {
                            id
                            name
                        }
                    }",
                Variables = new
                {
                    author = new
                    {
                        id = author.Id,
                        name = author.Name
                    }
                }
            };

            await _client.SendMutationAsync<AuthorQueryReponse>(mutation);
        }



        #endregion
    }
}
