namespace BikeShop.Entities;

public abstract class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool InStock { get; set; }
    public int AvailableQuantity { get; set; }
    public string Brand { get; set; }
    public int NumberOfPurchases { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public int ColorId { get; set; }
    public ICollection<Color> Colors { get; set; }

}