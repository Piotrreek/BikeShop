using BikeShop.Entities;

namespace BikeShop.Repositories;

public interface IBikeRepository
{
    Task InsertBike(Bike bike);
}

public class BikeRepository : IBikeRepository
{
    private readonly BikeShopContext _context;

    public BikeRepository(BikeShopContext context)
    {
        _context = context;
    }

    public async Task InsertBike(Bike bike)
    {
        await _context.Bikes.AddAsync(bike);
        await _context.SaveChangesAsync();
    }
}