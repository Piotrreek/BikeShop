using AutoMapper;
using BikeShop.Entities;
using BikeShop.Extensions;
using BikeShop.Interfaces;
using BikeShop.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Services;


public class AccountService : ValidationService<UserViewModel>, IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IValidator<UserViewModel> userValidator) : base(userValidator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserViewModel model)
    {
        var user = _mapper.Map<User>(model);

        var result = await _userManager.CreateAsync(user, model.Password);
        return result;
    }
    
}