using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class AuthorController : ControllerBase
{
    private BookStoreDbContext _context;
    private IMapper _mapper;

    public AuthorController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        var query = new GetAuthorsQuery(_context,_mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpGet("id")]
    public IActionResult GetById(int id)
    {
        var query = new GetAuthorDetailQuery(_context,_mapper);
        query.AuthorId = id;
        
        var validator = new GetAuthorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
    {
        var command = new CreateAuthorCommand(_context,_mapper);
        command.Model=model;
        
        var validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();

        return Ok();
    }

    [HttpPut("id")]
    public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel model)
    {
        var command = new UpdateAuthorCommand(_context);
        command.AuthorId = id;
        command.Model = model;
        
        var validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpDelete("id")]
    public IActionResult DeleteAuthor(int id)
    {
        var command = new DeleteAuthorCommand(_context);
        command.AuthorId=id;

        var validator = new DeleteAuthorCommandValidator(_context);
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}