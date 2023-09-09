using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.BookOperations.Commands
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Book can not be found");
            }
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;

            book.Title = Model.Title != default ? Model.Title : book.Title;
            _context.SaveChanges();
        }

    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }

    }
}

