using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBooks
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }
        

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Silinecek Olan Kitap Bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}