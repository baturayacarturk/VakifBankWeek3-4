﻿using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Contexts
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres{ get; set; }
        DbSet<Author> Authors{ get; set; }
        int SaveChanges();
    }
}
