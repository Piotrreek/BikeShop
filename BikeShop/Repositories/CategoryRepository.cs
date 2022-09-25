using BikeShop.Entities;
using Microsoft.EntityFrameworkCore;
using Type = BikeShop.Entities.Enums.Type;

namespace BikeShop.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesByCategoryTypeId(int categoryTypeId);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly BikeShopContext _context;

    public CategoryRepository(BikeShopContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesByCategoryTypeId(int categoryTypeId)
    {
        return await _context.Categories.Where(c => c.Type == (Type)categoryTypeId).ToListAsync();
    }
}