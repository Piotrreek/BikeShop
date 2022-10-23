using BikeShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
}

public class ProductRepository : IProductRepository
{
    private readonly BikeShopContext _context;

    public ProductRepository(BikeShopContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts() => await _context.Products
        .AsNoTracking()
        .Include(p => p.Category)
        .Include(p => p.Photos)
        .OrderByDescending(p => p.NumberOfPurchases)
        .ToListAsync();
}