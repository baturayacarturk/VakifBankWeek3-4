using BOOKSTORE.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c=>c.BookId).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Model.Title).NotEmpty();
            RuleFor(c=>c.Model.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
