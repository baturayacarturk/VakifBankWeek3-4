using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }
        private readonly IBookStoreDbContext _context;

        public CreateGenreCommand(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null) throw new InvalidOperationException("Book type is already exists");
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();

        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
