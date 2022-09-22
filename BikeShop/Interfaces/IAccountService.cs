using BikeShop.Entities.Enums;
using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Interfaces;

public interface IAccountService
{
    Task<bool> RegisterUserAsync(UserViewModel model, ModelStateDictionary modelState);
    Task<bool> LoginAsync(LoginViewModel model, ModelStateDictionary modelState);
    Task SignOutAsync();
    bool IsAuthenticated();
}