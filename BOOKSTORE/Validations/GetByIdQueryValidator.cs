using BOOKSTORE.Queries;
using FluentValidation;

namespace BOOKSTORE.Validations
{
    public class GetByIdQueryValidator:AbstractValidator<GetById>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(c => c.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
