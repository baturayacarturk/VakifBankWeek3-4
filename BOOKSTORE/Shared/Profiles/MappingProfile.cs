using AutoMapper;
using BOOKSTORE.Application.AuthorOperations.Commands;
using BOOKSTORE.Application.AuthorOperations.Queries;
using BOOKSTORE.Application.BookOperations.Queries;
using BOOKSTORE.Application.GenreOperations.Queries;
using BOOKSTORE.Entities;
using static BOOKSTORE.Application.BookOperations.Commands.CreateBookCommand;

namespace BOOKSTORE.Shared.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>().ReverseMap();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, string>().ConvertUsing(genre => genre.Name);

            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.BirthDate.ToString("dd/mm/yyyy")))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

        }
    }
}
