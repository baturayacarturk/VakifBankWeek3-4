using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using BOOKSTORE.Shared;

namespace BOOKSTORE.Queries
{
    public class GetBooks
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooks(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> booksModel = _mapper.Map<List<BooksViewModel>>(bookList);
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
