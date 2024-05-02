using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Genre
        CreateMap<Genre,GenresViewModel>();
        CreateMap<Genre,GenreDetailViewModel>();

        //Author
        CreateMap<CreateAuthorModel,Author>();
        CreateMap<Author,AuthorsViewModel>();
        CreateMap<Author,AuthorDetailViewModel>();

        //Books
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book,BookDetailViewModel>()
            .ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.AuthorName, opt=>opt.MapFrom(src => $"{src.Author.Name} {src.Author.LastName}"))
            .ForMember(dest=>dest.AuthorId, opt => opt.MapFrom(src=>src.AuthorId));
        CreateMap<Book, BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.LastName}"))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id));
    }
}