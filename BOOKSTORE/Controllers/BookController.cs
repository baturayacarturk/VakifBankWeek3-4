using BOOKSTORE.Commands;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using BOOKSTORE.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BOOKSTORE.Commands.CreateBookCommand;
using static BOOKSTORE.Commands.UpdateBookCommand;

namespace BOOKSTORE.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooks query = new GetBooks(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("list")]
        public List<Book> ListBooks([FromQuery] string name = "")
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(book => book.Title.Contains(name));
            }
            query = query.OrderBy(book => book.Title);

            var bookList = query.ToList();
            return bookList;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetById query = new GetById(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel book)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = book;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteCommand command = new DeleteCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();

        }
    }
}
