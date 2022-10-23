using BikeShop.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[Route("search")]
public class SearchController : Controller
{
    private readonly IMediator _mediator;

    public SearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var response = await _mediator.Send(query);

        return View(response);
    }
}