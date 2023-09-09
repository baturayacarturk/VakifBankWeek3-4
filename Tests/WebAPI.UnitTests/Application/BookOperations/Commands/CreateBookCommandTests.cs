using AutoMapper;
using BOOKSTORE.Application.BookOperations.Commands;
using BOOKSTORE.Contexts;
using BOOKSTORE.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.UnitTests.TestsSetup;

namespace WebAPI.UnitTests.Application.BookOperations.Commands
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;

        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn()
        {
            var book = new Book { Title = "abc", PageCount = 100, PublishDate = DateTime.Now, GenreId = 1, AuthorId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new BOOKSTORE.Application.BookOperations.Commands.CreateBookCommand.CreateBookModel()
            {
                Title = book.Title,
            };
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book already exists");
        }


    }
}
