using BOOKSTORE.Application.GenreOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Genres
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(c => c.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);

        }
    }
}
