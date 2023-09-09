using BOOKSTORE.Application.BookOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Books
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.BookId).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty();
            RuleFor(c => c.Model.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
