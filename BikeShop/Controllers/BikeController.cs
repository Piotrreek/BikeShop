using BikeShop.Commands;
using BikeShop.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[Route("bike")]
public class BikeController : Controller
{
    private readonly IMediator _mediator;

    public BikeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize]
    [HttpGet("create-bike")]
    public  IActionResult CreateBike()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost("create-bike")]
    public async Task<IActionResult> CreateBike([FromForm] CreateBikeViewModel model)
    {
        var command = new CreateBikeCommand(model, ModelState);
        var response = await _mediator.Send(command);
        
        if (response == false)
            return View(model);
        
        return RedirectToAction("CreateBike");
    }
}