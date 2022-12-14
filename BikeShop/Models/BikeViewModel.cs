using BikeShop.Entities;
using BikeShop.Entities.Enums;

namespace BikeShop.Models;

public class BikeViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool InStock { get; set; }
    public int AvailableQuantity { get; set; }
    public string Brand { get; set; }
    public List<string> ImageNames { get; set; } = new List<string>();
    public string ThumbnailName { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }
    public Gender UserGender { get; set; }
    public string ProductionYear { get; set; }
    
}