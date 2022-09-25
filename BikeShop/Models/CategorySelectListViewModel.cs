using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.Models;

public class CategorySelectListViewModel
{
    public int CategoryId { get; set; }
    public IEnumerable<SelectListItem> SelectList { get; set; }
}