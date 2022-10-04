using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.Models;

public class ColorSelectListViewModel
{
    public IEnumerable<SelectListItem> Items { get; set; }
    public int ColorId { get; set; }
}