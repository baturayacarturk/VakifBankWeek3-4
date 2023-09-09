using AutoMapper;
using BOOKSTORE.Application.AuthorOperations.Commands;
using BOOKSTORE.Application.AuthorOperations.Queries;
using BOOKSTORE.Application.BookOperations.Commands;
using BOOKSTORE.Contexts;
using BOOKSTORE.Validations.Author;
using BOOKSTORE.Validations.Books;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(CreateAuthorModel author)
        {
            try
            {
                CreateAuthorCommand command = new CreateAuthorCommand(_mapper, _context);
                command.Model = author;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            AuthorViewModel result;
            try
            {
                GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
                query.AuthorId = id;
                result = query.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpGet("getAll")]
        public IActionResult GetAllAuthors()
        {
            GetAllAuthorQuery query = new GetAllAuthorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, AuthorUpdateViewModel model)
        {
            try
            {
                UpdateAuthorCommand command = new UpdateAuthorCommand(_mapper, _context);
                command.AuthorId = id;
                command.Model = model;
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
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
        public IActionResult DeleteAuthor(int id) 
        {
            try
            {
                DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
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
