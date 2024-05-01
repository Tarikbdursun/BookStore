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
        //Books
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name));
        CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.AuthorName, opt=>opt
                                                            .MapFrom(src=> src.Author.Name+" "+src.Author.LastName));
        CreateMap<Book,BooksViewModel>().ForMember(dest => dest.AuthorName, opt=>opt
                                                            .MapFrom(src=>src.Author.Name + " "+src.Author.LastName));
        CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.AuthorId, opt=>opt
                                                            .MapFrom(src=> src.Author.Id));
        CreateMap<Book,BooksViewModel>().ForMember(dest => dest.AuthorId, opt=>opt
                                                            .MapFrom(src=>src.Author.Id));
        
        //Genre
        CreateMap<Genre,GenresViewModel>();
        CreateMap<Genre,GenreDetailViewModel>();

        //Author
        CreateMap<CreateAuthorModel,Author>();
        CreateMap<Author,AuthorsViewModel>();
        CreateMap<Author,AuthorDetailViewModel>();
    }

    //"error": "Required properties '{'LastName'}' are missing for the instance of entity type 'Author'. 
    //Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the entity key value."
}