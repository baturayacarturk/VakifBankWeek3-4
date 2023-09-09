using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Book type can not be found");
            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }
    }
    
}
