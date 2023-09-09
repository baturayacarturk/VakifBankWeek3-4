using BOOKSTORE.Contexts;

namespace BOOKSTORE.Application.AuthorOperations.Commands
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null) throw new InvalidOperationException("Author cannot be found");

            var booksToRemove = _context.Books.Where(x => x.Genre.IsActive && x.AuthorId == AuthorId).ToList();

            foreach (var book in booksToRemove)
            {
                author.Books.Remove(book);
            }
            _context.SaveChanges();
        }
    }
}
