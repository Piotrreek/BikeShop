using FluentValidation;

namespace BikeShop.Models.Validators;

public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
{
    public LoginViewModelValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Insert your username");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Insert your password!");
    }
}