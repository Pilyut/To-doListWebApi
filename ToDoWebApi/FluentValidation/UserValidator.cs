using BusinessLogicLayer.DTO;
using FluentValidation;

namespace ToDoWebApi.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("User name is empty")
                .NotNull().WithMessage("User name is null");
        }
    }
}
