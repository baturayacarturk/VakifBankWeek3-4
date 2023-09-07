using AutoMapper;
using BOOKSTORE.Entities;
using BOOKSTORE.Queries;
using static BOOKSTORE.Commands.CreateBookCommand;

namespace BOOKSTORE.Shared.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}
