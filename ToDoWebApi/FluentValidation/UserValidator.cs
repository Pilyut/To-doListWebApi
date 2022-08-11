using BusinessLogicLayer.DTO;
using FluentValidation;

namespace ToDoWebApi.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("User name is empty");
            RuleFor(user => user.UserName)
                .NotNull().WithMessage("User name is null");
            //RuleFor(user => user.Login.ToLower())
              //  .NotEmpty().NotNull().EmailAddress().WithMessage("Incorrect Email Address");
        }
    }
}
