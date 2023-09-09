using AutoMapper;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;

namespace BOOKSTORE.Application.AuthorOperations.Commands
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public AuthorUpdateViewModel Model;

        public UpdateAuthorCommand(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Author can not be found");
            author.FirstName = Model.FirstName == default ? author.FirstName : Model.FirstName;
            author.LastName = Model.LastName == default ? author.LastName : Model.LastName;
            _context.SaveChanges();
        }
    }

    public class AuthorUpdateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
