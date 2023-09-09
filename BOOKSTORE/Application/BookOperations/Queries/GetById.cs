using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Shared;

namespace BOOKSTORE.Application.BookOperations.Queries
{
    public class GetById
    {
        private readonly IBookStoreDbContext _context;
        public int BookId { get; set; }
        private readonly IMapper _mapper;

        public GetById(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Where(book => book.Id == BookId).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Book already exists");
            }
            BookDetailViewModel model = _mapper.Map<BookDetailViewModel>(book);

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
