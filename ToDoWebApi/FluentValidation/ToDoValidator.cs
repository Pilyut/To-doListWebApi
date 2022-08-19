using FluentValidation;
using BusinessLogicLayer.DTO;

namespace ToDoWebApi.FluentValidation
{
    public class ToDoValidator : AbstractValidator<ToDoDTO>
    {
        public ToDoValidator()
        {
            RuleFor(todo => todo.Task)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithMessage("Minimum length - 2 characters");   
        }
    }
}
