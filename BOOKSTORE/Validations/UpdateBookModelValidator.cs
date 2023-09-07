using BOOKSTORE.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations
{
    public class UpdateBookModelValidator:AbstractValidator<UpdateBookModel>
    {
        public UpdateBookModelValidator()
        {
            RuleFor(c=>c.Title).NotEmpty(); 
            RuleFor(c=>c.GenreId).NotEmpty().NotNull();
        }
    }
}
