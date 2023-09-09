using BOOKSTORE.Contexts;
using static BOOKSTORE.Application.BookOperations.Commands.CreateBookCommand;

namespace BOOKSTORE.Application.BookOperations.Commands
{
    public class DeleteCommand
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null) throw new InvalidOperationException("Book can not be found");
            
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
