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
        
        var registerResult = await _accountService.RegisterUserAsync(model, ModelState);

        if (registerResult == false)
        {
            return View(model);
        }

        TempData["registerResult"] = true;
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        // napisac metode co sprawdzi zalogowanie i wywali do index jest tak
        return View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm]LoginViewModel model)
    {
        var loginResult = await _accountService.LoginAsync(model, ModelState);
        
        if (loginResult == false)
        {
            return View(model);
        }
        
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}