using FluentValidation;
using BusinessLogicLayer.DTO;

namespace ToDoWebApi.FluentValidation
{
    public class ToDoValidator : AbstractValidator<ToDoDTO>
    {
        public ToDoValidator()
        {
            RuleFor(todo => todo.Task)
                .MinimumLength(2).NotEmpty().NotNull().WithMessage("Minimum length - 2 characters");   
        }
    }
}
