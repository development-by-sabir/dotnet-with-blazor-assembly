using BSMSShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreManagementSystem.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data into Author table
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Charles Darwin" },
                new Author() { Id = 2, Name = "Richard Dawkins" },
                new Author() { Id = 3, Name = "Rachel Carson" },
                new Author() { Id = 4, Name = "Carl Sagan" },
                new Author() { Id = 5, Name = "Unknown" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Title = "On the origin of Species", Price = 250, AuthorId = 1 },
                new Book() { Id = 2, Title = "The Selfish Gene", Price = 300, AuthorId = 2 },
                new Book() { Id = 3, Title = "Silent Spring", Price = 350, AuthorId = 3 },
                new Book() { Id = 4, Title = "Cosmos", Price = 400, AuthorId = 4 },
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
