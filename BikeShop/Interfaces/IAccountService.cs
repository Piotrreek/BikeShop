using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Interfaces;

public interface IAccountService
{
    Task<IdentityResult> RegisterUserAsync(UserViewModel user);
    Task<bool> ValidateAsync(UserViewModel model, ModelStateDictionary modelState);
}