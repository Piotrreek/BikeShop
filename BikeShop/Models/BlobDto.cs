namespace BikeShop.Models;

public class BlobDto
{
    public string Name { get; set; }
    public string ContentType { get; set; }
    public Stream Content { get; set; }
}