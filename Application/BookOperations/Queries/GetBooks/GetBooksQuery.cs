using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList=_dbContext.Books
                            .Include(x=>x.Author)
                            .Include(x=>x.Genre)
                            .OrderBy(x=>x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
            // foreach (Book book in bookList)
            // {
            //     vm.Add(new BooksViewModel
            //     {
            //         Title=book.Title,
            //         PageCount=book.PageCount,
            //         Genre=((GenreEnum)book.GenreId).ToString(),
            //         PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy")
            //     });
            // }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
    }
}