using BikeShop.Extensions;
using BikeShop.Interfaces;
using BikeShop.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[Route("account")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService, IValidator<UserViewModel> userValidator)
    {
        _accountService = accountService;
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm]UserViewModel model)
    {
        var validationResult = await _accountService.ValidateAsync(model, ModelState);
        
        if (validationResult is false)
            return View(model);
        
        var registerResult = await _accountService.RegisterUserAsync(model);

        if (registerResult.Succeeded is false)
        {
            registerResult.AddToModelState(ModelState);
            return View(model);
        }

        TempData["registerResult"] = true;
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}