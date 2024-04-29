using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommand
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateAuthorModel Model { get; set; }

    public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x=>x.Name == Model.Name 
                        && x.LastName==Model.LastName 
                        && x.Birthdate.Date==Model.BirthDate.Date);

        if(author is not null)
            throw new InvalidOperationException("Bu Yazar Zaten Var");

        author = _mapper.Map<Author>(Model);

        _context.Authors.Add(author);
        _context.SaveChanges();
    }
}

public class CreateAuthorModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}