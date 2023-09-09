using AutoMapper;
using BOOKSTORE.Contexts;

namespace BOOKSTORE.Application.GenreOperations.Queries
{
    public class GetGenreDetailQuery
    {
        private readonly IBookStoreDbContext _context;
        public int GenreId { get; set; }
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public GenreDetailViewModel Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genres is null) throw new InvalidOperationException("Book type can not be found");
            GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genres);
            return returnObj;
        }

    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
