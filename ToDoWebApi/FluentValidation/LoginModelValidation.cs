using FluentValidation;
using BusinessLogicLayer.Models;

namespace ToDoWebApi.FluentValidation
{
    public class LoginModelValidation : AbstractValidator<LoginModel>
    {
        public LoginModelValidation()
        {
            RuleFor(model => model.Email)
                .NotNull()
                .EmailAddress()
                .WithMessage("Incorrect Email Address");
            RuleFor(model => model.Password)
                .NotNull()
                .Length(6, 30);
        }
    }
}
