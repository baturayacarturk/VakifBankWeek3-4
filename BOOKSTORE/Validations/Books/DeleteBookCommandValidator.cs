using BOOKSTORE.Application.BookOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Books
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
