namespace BikeShop.Models;

public class CreateBikeViewModel : CreateProductViewModel
{
    public int ColorId { get; set; }
    public int Size { get; set; }
    public int UserGender { get; set; }
    public string ProductionYear { get; set; }
}