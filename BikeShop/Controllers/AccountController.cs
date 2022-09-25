using BikeShop.Commands;
using BikeShop.Models;
using BikeShop.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[Route("account")]
public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("register")]
    public async Task<IActionResult> Register()
    {
        var query = new CheckIfUserIsSignedInQuery();
        var response = await _mediator.Send(query);
        
        return response == true 
            ? RedirectToAction(nameof(HomeController.Index), "Home")
            : View();
    }
    
    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm]UserViewModel model)
    {
        var command = new RegisterUserCommand(model, ModelState);
        var response = await _mediator.Send(command);
        
        if (response == false)
            return View(model);
        
        TempData["registerResult"] = true;
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        var query = new CheckIfUserIsSignedInQuery();
        var response = await _mediator.Send(query);
        
        return response == true 
            ? RedirectToAction(nameof(HomeController.Index), "Home")
            : View();
    }
    
    [ValidateAntiForgeryToken]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm]LoginViewModel model)
    {
        var command = new LoginUserCommand(model, ModelState);
        var response = await _mediator.Send(command);
        
        if (response == false)
            return View(model);
        
        
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpPost("sign-out")]
    public new async Task<IActionResult> SignOut()
    {
        var command = new SignOutUserCommand();
        await _mediator.Send(command);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
