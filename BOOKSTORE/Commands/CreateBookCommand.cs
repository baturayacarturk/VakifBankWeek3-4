using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Commands
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var result = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (result is not null)
            {
                throw new InvalidOperationException("Book already exists");
            }
            result = new Book();
            result.Title = Model.Title;
            result.PublishDate = Model.PublishDate;
            result.PageCount = Model.PageCount;
            result.GenreId=Model.GenreId;

            _context.Add(result);
            _context.SaveChanges();
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
