using BSMSClient;
using BSMSClient.Services;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BSMSClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Register HttpClient for regular HTTP calls (e.g., fetching files or APIs)
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Register GraphQLHttpClient
            builder.Services.AddScoped(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                return new GraphQLHttpClient(
                    new GraphQLHttpClientOptions
                    {
                        EndPoint = new Uri("https://localhost:7201/graphql")
                    },
                    new NewtonsoftJsonSerializer(),
                    httpClient);
            });

            // Register custom service for calling GraphQL API
            builder.Services.AddScoped<BookStoreGraphQLService>();

            await builder.Build().RunAsync();
        }
    }
}
