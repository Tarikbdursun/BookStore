using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail;

public class GetBookQueryValidator:AbstractValidator<GetBookQuery>
{
    public GetBookQueryValidator()
    {
        RuleFor(command=>command.BookId).GreaterThan(0);
    }
}