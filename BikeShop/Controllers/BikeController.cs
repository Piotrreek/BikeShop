using BikeShop.Commands;
using BikeShop.Models;
using BikeShop.Queries;
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
    [HttpGet("create")]
    public  IActionResult CreateBike()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateBike([FromForm] CreateBikeViewModel model)
    {
        var command = new CreateBikeCommand(model, ModelState);
        var response = await _mediator.Send(command);
        
        if (response == false)
            return View(model);
        
        return RedirectToAction("CreateBike");
    }

    [HttpGet("get-by-id/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetBikeByIdQuery(id);
        var response = await _mediator.Send(query);
        return View(response);
    }
}