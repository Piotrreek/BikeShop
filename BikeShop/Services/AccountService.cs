﻿using AutoMapper;
using BikeShop.Entities;
using BikeShop.Extensions;
using BikeShop.Interfaces;
using BikeShop.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Services;


public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IValidationService<UserViewModel> _userViewModelValidator;
    private readonly IValidationService<LoginViewModel> _loginViewModelValidator;

    public AccountService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IMapper mapper,
        IValidationService<UserViewModel> userViewModelValidator,
        IValidationService<LoginViewModel> loginViewModelValidator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _userViewModelValidator = userViewModelValidator;
        _loginViewModelValidator = loginViewModelValidator;
    }

    public async Task<bool> RegisterUserAsync(UserViewModel model, ModelStateDictionary modelState)
    {
        var validationResult = await _userViewModelValidator.ValidateAsync(model, modelState);

        if (validationResult == false)
        {
            return false;
        }
        
        var user = _mapper.Map<User>(model);
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (!result.Succeeded)
        {
            result.AddToModelState(modelState);
            return false;
        }

        return true;
    }

    public async Task<bool> LoginAsync(LoginViewModel model, ModelStateDictionary modelState)
    {
        var validationResult = await _loginViewModelValidator.ValidateAsync(model, modelState);
        
        if (validationResult == false)
        {
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

        if (!result.Succeeded)
        {
            modelState.AddModelError("", "Invalid e-mail or password");
            return false;
        }

        return true;
    }
}
