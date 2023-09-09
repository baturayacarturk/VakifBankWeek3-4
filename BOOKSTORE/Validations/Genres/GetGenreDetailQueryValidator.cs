using BOOKSTORE.Application.GenreOperations.Queries;
using FluentValidation;

namespace BOOKSTORE.Validations.Genres
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);

        }
    }
}
