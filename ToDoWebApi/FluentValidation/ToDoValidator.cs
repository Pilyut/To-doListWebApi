using FluentValidation;
using BusinessLogicLayer.DTO;

namespace ToDoWebApi.FluentValidation
{
    public class ToDoValidator : AbstractValidator<ToDoDTO>
    {
        public ToDoValidator()
        {
            RuleFor(todo => todo.Task).NotEmpty().WithMessage("Task is empty");
            RuleFor(todo => todo.Task).NotNull().WithMessage("Task is null");
        }
    }
}
