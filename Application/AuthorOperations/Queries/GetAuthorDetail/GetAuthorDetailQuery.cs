using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }

    public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public AuthorDetailViewModel Handle()
    {
        var author= _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if(author is null)
            throw new InvalidOperationException("Yazar Bulunamadı");

        return _mapper.Map<AuthorDetailViewModel>(author);//new AuthorDetailViewModel 
        // {
        //     Id = author.Id,
        //     Name= author.Name,
        //     LastName = author.LastName,
        //     BirthDate = author.Birthdate
        // };
    }
    
}

public class AuthorDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public object BirthDate { get; set; }
}