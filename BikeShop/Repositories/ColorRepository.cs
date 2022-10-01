using BikeShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repositories;

public interface IColorRepository
{
    Task<Color> GetColorByIdAsync(int colorId);
}

public class ColorRepository : IColorRepository
{
    private readonly BikeShopContext _context;

    public ColorRepository(BikeShopContext context)
    {
        _context = context;
    }

    public async Task<Color> GetColorByIdAsync(int colorId)
    {
        return await _context.Colors.FirstOrDefaultAsync(c => c.Id == colorId);
    }
}