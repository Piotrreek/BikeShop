using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BikeShop.Models;

namespace BikeShop.Services;

public interface IAzureBlobService
{
    Task<BlobDto> GetBlobContentAsync(string blobFileName);
    Task UploadBlobAsync(string blobName, IFormFile blob);
}

public class AzureBlobService : IAzureBlobService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IConfiguration _configuration;
    
    public AzureBlobService(BlobServiceClient blobServiceClient, IConfiguration configuration)
    {
        _blobServiceClient = blobServiceClient;
        _configuration = configuration;
    }

    public async Task<BlobDto> GetBlobContentAsync(string blobFileName)
    {
        var containerClient = await GetContainerClientAsync();
        var blobClient = containerClient.GetBlobClient(blobFileName);
        var data = await blobClient.OpenReadAsync();

        var content = await blobClient.DownloadContentAsync();
        var name = blobFileName;
        var contentType = content.Value.Details.ContentType;

        return new BlobDto { Content = data, Name = name, ContentType = contentType };
    }
    
    public async Task UploadBlobAsync(string blobFileName, IFormFile blob)
    {
        var containerClient = await GetContainerClientAsync();
        var blobClient = containerClient.GetBlobClient(blobFileName);

        await using var data = blob.OpenReadStream();

        await blobClient.UploadAsync(data, new BlobHttpHeaders
        {
            ContentType = $"image/jpeg"
        });
    }
    
    
    private async Task<BlobContainerClient> GetContainerClientAsync()
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_configuration["ConnectionStrings:AzureBlobContainerName"]);

        await blobContainerClient.CreateIfNotExistsAsync();

        return blobContainerClient;
    }
}