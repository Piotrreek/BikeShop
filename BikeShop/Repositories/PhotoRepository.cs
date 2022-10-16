using BikeShop.Entities;
using BikeShop.Models;
using BikeShop.Services;

namespace BikeShop.Repositories;

public interface IPhotoRepository
{
    Task<Photo> UploadPhoto(IFormFile file, bool isThumbnail = false);
}

public class PhotoRepository : IPhotoRepository
{
    private readonly BikeShopContext _context;
    private readonly IAzureBlobService _azureBlobService;

    public PhotoRepository(BikeShopContext context, IAzureBlobService azureBlobService)
    {
        _context = context;
        _azureBlobService = azureBlobService;
    }

    public async Task<Photo> UploadPhoto(IFormFile file, bool isThumbnail = false)
    {
        var blobName = Guid.NewGuid().ToString().Replace('-', (char)new Random().Next(97, 122)) + Path.GetExtension(file.FileName);
        await _azureBlobService.UploadBlobAsync(blobName, file);
        
        var photo = new Photo
        {
            IsThumbnail = isThumbnail,
            PhotoPath = blobName
        };

        await _context.Photos.AddAsync(photo);
        return photo;
    }
}