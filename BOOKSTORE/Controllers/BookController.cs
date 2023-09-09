using AutoMapper;
using BOOKSTORE.Application.BookOperations.Commands;
using BOOKSTORE.Application.BookOperations.Queries;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using BOOKSTORE.Validations.Books;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BOOKSTORE.Application.BookOperations.Commands.CreateBookCommand;
using static BOOKSTORE.Application.BookOperations.Commands.UpdateBookCommand;

namespace BOOKSTORE.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooks query = new GetBooks(_context, _mapper);
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
                GetById query = new GetById(_context, _mapper);
                query.BookId = id;
                GetByIdQueryValidator validator = new GetByIdQueryValidator();
                validator.ValidateAndThrow(query);
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
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = book;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                ValidationResult results = validator.Validate(command);
                validator.ValidateAndThrow(command);
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
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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
