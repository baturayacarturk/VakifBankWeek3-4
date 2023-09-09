using BOOKSTORE.Application.GenreOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Genres
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
