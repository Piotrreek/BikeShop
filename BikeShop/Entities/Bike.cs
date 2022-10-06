using BikeShop.Entities.Enums;
using BikeShop.Entities.Interfaces;

namespace BikeShop.Entities;

public class Bike : Product, IProductionYear
{
    
    public Size Size { get; set; }
    public Gender UserGender { get; set; }
    public string ProductionYear { get; set; }
}