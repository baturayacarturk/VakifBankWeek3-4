using BOOKSTORE.Contexts;
using static BOOKSTORE.Commands.CreateBookCommand;

namespace BOOKSTORE.Commands
{
    public class DeleteCommand
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteCommand(BookStoreDbContext context)
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
