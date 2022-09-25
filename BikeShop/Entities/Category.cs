namespace BikeShop.Entities;

public class Category
{
    public int Id { get; set; }
    public BikeShop.Entities.Enums.Type Type { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}