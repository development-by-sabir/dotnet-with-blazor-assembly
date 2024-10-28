using GraphQL.Client.Http;
using GraphQL;
using BSMSShared.DTO;

namespace BSMSystemClient.Services
{
    public class BookStoreGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public BookStoreGraphQLService(GraphQLHttpClient client)
        {
            _client = client;
        }

        //public async Task<List<BookDto>> GetBooksAsync()
        //{
        //    var query = new GraphQLRequest
        //    {
        //        Query = @"
        //        {
        //            books {
        //                id
        //                title
        //                author {
        //                    name
        //                }
        //            }
        //        }"
        //    };

        //    var response = await _client.SendQueryAsync<List<BookDto>>(query);
        //    return response.Data;
        //}

        //public async Task<BookDto> AddBookAsync(string title, int authorId)
        //{
        //    var mutation = new GraphQLRequest
        //    {
        //        Query = @"
        //            mutation($title: String!, $authorId: Int!) {
        //                addBook(title: $title, authorId: $authorId) {
        //                    id
        //                    title
        //                }
        //            }",
        //            Variables = new { title, authorId }
        //        };

        //    var response = await _client.SendMutationAsync<BookDto>(mutation);
        //    return response.Data;
        //}

        #region Author GraphQL Service
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

            var response = await _client.SendQueryAsync<List<AuthorDto>>(query);
            return response.Data;
        }

        //private async Task DeleteProduct(int id)
        //{
        //    var mutation = $@"
        //        mutation {{
        //            deleteProduct(id: {id})
        //        }}";
        //    await GraphQLService.ExecuteQuery<bool>(mutation);
        //    products = products.Where(p => p.Id != id).ToList();
        //}

        #endregion
    }
}
