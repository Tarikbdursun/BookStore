using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors;

public class GetAuthorsQuery
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<AuthorsViewModel> Handle()
    {
        return _mapper.Map<List<AuthorsViewModel>>(_context.Authors.OrderBy(x => x.Id).ToList());
    }

}
public class AuthorsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}