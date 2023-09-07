using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using BOOKSTORE.Shared;

namespace BOOKSTORE.Queries
{
    public class GetBooks
    {
        private readonly BookStoreDbContext _context;
        
        public GetBooks(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> booksModel = new List<BooksViewModel>();
            foreach(var item in bookList)
            {
                booksModel.Add(new BooksViewModel
                {
                    Title = item.Title,
                    Genre = ((GenreEnum)item.GenreId).ToString(),
                    PublishDate = item.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = item.PageCount, 
                }); 
            }
            return booksModel;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
