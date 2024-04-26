using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBooks;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using FluentValidation.Results;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using FluentValidation;
using AutoMapper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_context,_mapper);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;

            GetBookQuery query = new GetBookQuery(_context,_mapper);
            query.BookId = id;
            GetBookQueryValidator validator=new();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //--POST--
        [HttpPost()]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            
            command.Model = newBook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle(); 

            return Ok();
        }

        //--PUT--
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new(_context);
            command.BookId = id;
            command.Model = updatedBook;
            UpdateBookCommandValidator validator=new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        //--DELETE**
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}