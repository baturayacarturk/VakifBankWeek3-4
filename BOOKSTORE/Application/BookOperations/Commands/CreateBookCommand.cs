using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.BookOperations.Commands
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var result = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (result is not null)
            {
                throw new InvalidOperationException("Book already exists");
            }
            result = _mapper.Map<Book>(Model);
            _context.Books.Add(result);
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
