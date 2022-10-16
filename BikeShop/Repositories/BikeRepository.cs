using BikeShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repositories;

public interface IBikeRepository
{
    Task InsertBike(Bike bike);
    Task<Bike> GetBikeById(Guid guid);
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
    
    public async Task<Bike> GetBikeById(Guid guid) => await _context.Bikes
        .Include(b => b.Photos)
        .Include(b => b.Color)
        .AsNoTracking()
        .FirstOrDefaultAsync(b => b.Id == guid);
}