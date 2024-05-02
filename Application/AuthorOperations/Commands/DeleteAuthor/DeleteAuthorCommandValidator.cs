using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    private readonly BookStoreDbContext _context;

    public DeleteAuthorCommandValidator(BookStoreDbContext context)
    {
        _context = context;
        RuleFor(command=>command.AuthorId).GreaterThan(0);
        RuleFor(command=>command.AuthorId).Must(HasAuthorPublishedBook).WithMessage("Kitabı Yayında Olan Yazar Silinemez");
    }

    private bool HasAuthorPublishedBook(int authorId)
    {
        return !_context.Books.Any(book => book.AuthorId == authorId);
    }
}