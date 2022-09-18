using FluentValidation;
namespace BikeShop.Models.Validators;

public class UserViewModelValidator : AbstractValidator<UserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Insert your password!");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Insert value equal to your password!")
            .Equal(x => x.Password).WithMessage("Password and Confirm Password values must be the same!");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Insert e-mail address!")
            .EmailAddress().WithMessage("Insert correct e-mail address!");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Insert your first name!");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Insert your last name!");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Insert your username!");
    }
}