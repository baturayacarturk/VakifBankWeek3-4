using AutoMapper;
using BOOKSTORE.Application.GenreOperations.Commands;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.AuthorOperations.Commands
{
    public class CreateAuthorCommand
    {
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _context;

        public CreateAuthorCommand(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var result = _context.Authors.SingleOrDefault(x=>x.FirstName == Model.FirstName&& x.LastName == Model.LastName&&x.BirthDate==Model.BirthDate);
            if (result != null) throw new InvalidOperationException("Author is already exists");
            var toBeAdded = _mapper.Map<Author>(Model);
            _context.Authors.Add(toBeAdded);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
