using BookstoreManagementSystem.Data;
using BookstoreManagementSystem.GraphQL;
using BSMSShared.Interfaces;
using BookstoreManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Serilog;

namespace BookstoreManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Configure Serilog to log to a file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(System.IO.Path.Join(Directory.GetCurrentDirectory(), "Logs/server-logfile.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Host.UseSerilog();

            Log.Information("Starting server application");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy to allow all origins
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

           
            builder.Services.AddDbContext<BookstoreDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


            builder.Services.AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CORSPolicy");

            app.UseRouting();

            app.MapGraphQL("/graphql");

            app.MapControllers();

            app.Run();
        }
    }
}
