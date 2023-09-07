using BOOKSTORE.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
        }
    }
}
