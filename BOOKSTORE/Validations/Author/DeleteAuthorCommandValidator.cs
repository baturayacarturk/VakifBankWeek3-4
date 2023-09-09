using BOOKSTORE.Application.AuthorOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Author
{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(c=>c.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
