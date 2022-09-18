using BikeShop.Entities.Enums;
using BikeShop.Entities.Interfaces;

namespace BikeShop.Entities;

public class MountainBike : Product, IProductionYear
{
    public Size Size { get; set; }
    public string ProductionYear { get; set; }
}