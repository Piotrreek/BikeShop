using BikeShop.Commands;
using BikeShop.Entities;
using BikeShop.Enums;
using BikeShop.Models;
using BikeShop.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BikeShop.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
{
    private readonly SignInManager<User> _signInManager;
    private readonly IValidationService<LoginViewModel> _validator;

    public LoginUserCommandHandler(SignInManager<User> signInManager, IValidationService<LoginViewModel> validator)
    {
        _signInManager = signInManager;
        _validator = validator;
    }

    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Model, request.ModelState);
        if (validationResult == ValidationResult.Fail)
            return false;
        
        var result = await _signInManager.PasswordSignInAsync(request.Model.UserName, request.Model.Password, true, false);

        if (!result.Succeeded)
        {
            request.ModelState.AddModelError("", "Invalid username or password");
            return false;
        }

        return true;
    }
}