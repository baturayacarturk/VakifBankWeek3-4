using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.UnitTests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            var authors = context.Authors.ToList();
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
        }

    }
}
