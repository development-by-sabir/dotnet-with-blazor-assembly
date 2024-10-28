using BSMSystemClient;
using BSMSystemClient.Services;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(_ => new GraphQLHttpClient("https://localhost:7201/graphql", new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<BookStoreGraphQLService>();

await builder.Build().RunAsync();
