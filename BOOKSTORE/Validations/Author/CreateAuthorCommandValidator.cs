using BOOKSTORE.Application.AuthorOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Author
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(c=>c.Model.BirthDate).NotEmpty();
            RuleFor(c => c.Model.FirstName).NotEmpty();
            RuleFor(c => c.Model.LastName).NotEmpty();
            
        }
    }
}
