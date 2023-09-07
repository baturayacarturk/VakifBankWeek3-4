using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Contexts
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context is null)
                {
                    throw new InvalidOperationException("BookStoreDbContext is null.");
                }

                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(

                    new Book { Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = DateTime.Now },
                    new Book { Title = "Herland", GenreId = 2, PageCount = 250, PublishDate = new DateTime(2023, 01, 25) },
                    new Book { Title = "DuneStartup", GenreId = 2, PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
                    );
                context.SaveChanges();
            }

        }
    }
}
