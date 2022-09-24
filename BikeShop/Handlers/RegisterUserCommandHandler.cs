using AutoMapper;
using BikeShop.Commands;
using BikeShop.Entities;
using BikeShop.Enums;
using BikeShop.Extensions;
using BikeShop.Models;
using BikeShop.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BikeShop.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IValidationService<UserViewModel> _validator;

    public RegisterUserCommandHandler(UserManager<User> userManager, IMapper mapper, IValidationService<UserViewModel> validator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Model, request.ModelState);
        if (validationResult == ValidationResult.Fail)
            return false;

        var user = _mapper.Map<User>(request.Model);
        var result = await _userManager.CreateAsync(user, request.Model.Password);

        if (!result.Succeeded)
        {
            result.AddToModelState(request.ModelState);
            return false;
        }

        return true;
    }
}