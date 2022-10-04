using BikeShop.Models;
using BikeShop.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.ViewComponents;

public class ColorSelectListViewComponent : ViewComponent
{
    private readonly IMediator _mediator;

    public ColorSelectListViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var query = new GetColorsQuery();
        var response = await _mediator.Send(query);
        var colors = response.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
        var viewModel = new ColorSelectListViewModel { Items = colors };
        return View(viewModel);
    }
}