using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookQuery
    {
        private readonly IBookStoreDbContext _dbContext;
private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            Book book = _dbContext.Books
                            .Include(x => x.Author) 
                            .Include(x=>x.Genre) 
                            .FirstOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
                
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);//new BookDetailViewModel();
            // vm.Title = book.Title;
            // vm.Genre = ((GenreEnum)book.GenreId).ToString();
            // vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
            // vm.PageCount = book.PageCount;

            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string PublishDate { get; set; }
    }
}