using FluentValidation;

namespace WebApi.BookOperations.DeleteBooks
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
    }
}