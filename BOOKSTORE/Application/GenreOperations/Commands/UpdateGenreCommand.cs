using AutoMapper;
using BOOKSTORE.Contexts;

namespace BOOKSTORE.Application.GenreOperations.Commands
{
    public class UpdateGenreCommand
    {
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public UpdateGenreModel Model{ get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Book type can not be found");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId)) throw new InvalidOperationException("Already exists with same name");
            genre.Name = Model.Name.Trim() == default ? genre.Name :Model.Name ;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
