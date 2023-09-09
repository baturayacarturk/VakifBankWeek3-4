using BOOKSTORE.Application.AuthorOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Author
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(c=>c.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
