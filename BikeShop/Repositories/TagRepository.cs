using BikeShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Repositories;

public interface ITagRepository
{
    Task<Tag> InsertTag(string name);
}

public class TagRepository : ITagRepository
{
    private readonly BikeShopContext _context;

    public TagRepository(BikeShopContext context)
    {
        _context = context;
    }

    public async Task<Tag> InsertTag(string name)
    {
        var tag = await GetTagByName(name);
        if (tag != null) return tag;
        var newTag = new Tag
        {
            Name = name
        };
        await _context.Tags.AddAsync(newTag);
        await _context.SaveChangesAsync();
        return newTag;

    }

    private async Task<Tag> GetTagByName(string name) 
        => await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);

}