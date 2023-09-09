using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.UnitTests.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(

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


                    });
        }
    }
}
