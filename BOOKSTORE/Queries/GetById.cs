using BOOKSTORE.Contexts;
using BOOKSTORE.Shared;

namespace BOOKSTORE.Queries
{
    public class GetById
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }

        public GetById(BookStoreDbContext context)
        {
            _context = context;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Where(book => book.Id == BookId).FirstOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("Book already exists");
            }
            BookDetailViewModel model = new BookDetailViewModel();
            model.Title = book.Title;
            model.PageCount= book.PageCount;
            model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            model.Genre=((GenreEnum)book.GenreId).ToString();   
            return model;

        }

    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
