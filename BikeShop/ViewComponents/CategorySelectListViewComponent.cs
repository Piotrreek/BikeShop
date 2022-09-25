using BikeShop.Models;
using BikeShop.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.ViewComponents;

public class CategorySelectListViewComponent : ViewComponent
{
    private readonly IMediator _mediator;

    public CategorySelectListViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync(int categoryType)
    {
        var query = new GetCategoriesByCategoryTypeQuery(categoryType);
        var response = await _mediator.Send(query);
        var categories = response.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
        var viewModel = new CategorySelectListViewModel() { CategoryId = categoryType, SelectList = categories };
        
        return View(viewModel);
    }
}