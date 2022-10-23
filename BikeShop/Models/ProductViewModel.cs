using Type = BikeShop.Entities.Enums.Type;

namespace BikeShop.Models;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ThumbnailName { get; set; }
    public Type Type { get; set; }
}