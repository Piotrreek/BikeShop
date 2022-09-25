namespace BikeShop.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public string PhotoPath { get; set; }
    public bool IsThumbnail { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}