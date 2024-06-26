using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommand
{
    public CreateGenreModel Model { get; set; }
    private readonly IBookStoreDbContext _context;

    public CreateGenreCommand(IBookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var genre = _context.Genres.SingleOrDefault(x=>x.Name == Model.Name);
        if(genre is not null)
            throw new InvalidOperationException("Kitap Türü Zaten Var");

        genre = new Entities.Genre();
        genre.Name = Model.Name;
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }
}

public class CreateGenreModel
{
    public string Name { get; set;}
}