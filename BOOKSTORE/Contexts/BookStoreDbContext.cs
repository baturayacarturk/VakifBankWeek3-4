using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Contexts
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }


    }
}
