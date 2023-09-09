using BOOKSTORE.Application.GenreOperations.Commands;
using FluentValidation;

namespace BOOKSTORE.Validations.Genres
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(c => c.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
