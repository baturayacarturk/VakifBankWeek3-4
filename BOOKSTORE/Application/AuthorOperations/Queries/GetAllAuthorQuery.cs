using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Application.AuthorOperations.Queries
{
    public class GetAllAuthorQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAllAuthorQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var author = _context.Authors.Include(x => x.Books).ThenInclude(book => book.Genre);
            
            if (author is null) throw new InvalidOperationException("Author is not exist");

            var result = _mapper.Map<List<AuthorViewModel>>(author);
            return result;
        }
    }
}
