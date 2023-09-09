using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using BOOKSTORE.Shared;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Application.BookOperations.Queries
{
    public class GetBooks
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooks(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(x => x.Id).ToList();
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
