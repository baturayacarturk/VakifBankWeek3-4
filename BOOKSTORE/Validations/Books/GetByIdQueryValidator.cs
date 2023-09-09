using BOOKSTORE.Application.BookOperations.Queries;
using FluentValidation;

namespace BOOKSTORE.Validations.Books
{
    public class GetByIdQueryValidator : AbstractValidator<GetById>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(c => c.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
