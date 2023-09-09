using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    return; // Data already exists, no need to seed again
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    });

                var authors = new List<Author>
                {
                    new Author
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        BirthDate = new DateTime(1980, 5, 15)
                    },
                    new Author
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        BirthDate = new DateTime(1975, 10, 3)
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Martin",
                        BirthDate = new DateTime(1948, 9, 20)
                    }
                };

                context.Authors.AddRange(authors);

                // Add books directly to context.Books
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = DateTime.Now,
                        AuthorId = authors[0].Id
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2023, 01, 25),
                        AuthorId = authors[1].Id
                    },
                    new Book
                    {
                        Title = "DuneStartup",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21),
                        AuthorId = authors[2].Id
                    });

                context.SaveChanges();
            }
        }
    }
}
