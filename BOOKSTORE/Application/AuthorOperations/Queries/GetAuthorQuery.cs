using AutoMapper;
using BOOKSTORE.Application.BookOperations.Queries;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Application.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public AuthorViewModel Handle()
        {
            var author = _context.Authors.Include(x => x.Books).ThenInclude(book=>book.Genre).SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Author is not exist");

            var result = _mapper.Map<AuthorViewModel>(author);
            return result;
        }

    }
    public class AuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public List<BooksViewModel> Books { get; set; } = new List<BooksViewModel>();

    }
}

