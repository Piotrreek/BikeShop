using BikeShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

public class PhotoController : Controller
{
    private readonly IAzureBlobService _azureBlobService;

    public PhotoController(IAzureBlobService azureBlobService)
    {
        _azureBlobService = azureBlobService;
    }

    [HttpGet]
    public async Task<IActionResult> GetImage([FromQuery]string name)
    {
        var blobDto = await _azureBlobService.GetBlobContentAsync(name);
        using var memoryStream = new MemoryStream();
        await blobDto.Content.CopyToAsync(memoryStream);
        var data = memoryStream.ToArray();
        await memoryStream.DisposeAsync();
        
        return File(data, blobDto.ContentType);
    }
}
