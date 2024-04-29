using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommand
{
    private readonly BookStoreDbContext _context;
    public UpdateAuthorModel Model { get; set; }
    public int AuthorId { get; set; }

    public UpdateAuthorCommand(BookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Güncellenmek İstenen Yazar Bulunamadı");

        if(_context.Authors.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.LastName == Model.LastName && x.Id != AuthorId))
            throw new InvalidOperationException("Böyle Bir Yazar Zaten Mevcut");

        author.Birthdate = Model.Birthdate == default ? author.Birthdate : Model.Birthdate;
        author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
        author.LastName = string.IsNullOrEmpty(Model.Name.Trim()) ? author.LastName : Model.LastName;

        _context.SaveChanges();
    }
}

public class UpdateAuthorModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}