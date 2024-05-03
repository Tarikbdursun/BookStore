using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommand
{
    public readonly IBookStoreDbContext _context;
    public int AuthorId { get; set; }

    public DeleteAuthorCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Silinmek İstenen Yazar Bulunamadı");
        
        _context.Authors.Remove(author);
        _context.SaveChanges();
    }
}