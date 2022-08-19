using FluentValidation;
using BusinessLogicLayer.Models;

namespace ToDoWebApi.FluentValidation
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(model => model.Email)
                .NotNull()
                .EmailAddress()
                .WithMessage("Incorrect Email Address");
            RuleFor(model => model.Password)
                .NotNull()
                .Length(6, 30)
                .WithMessage("Password lenght must be between 6 - 30 characters");
            RuleFor(model => model.ConfirmPassword)
                .Equal(model => model.Password)
                .WithMessage("Passwords don't equal");

        }
    }
}
