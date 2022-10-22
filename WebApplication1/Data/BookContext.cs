/*using ContosoUniversity.Models;*/
using Microsoft.EntityFrameworkCore;
using BooksAPI.Models;

namespace ContosoUniversity.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}