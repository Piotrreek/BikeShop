using System.ComponentModel;
using BikeShop.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Models;

public abstract class CreateProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool InStock { get; set; }
    public int AvailableQuantity { get; set; }
    public string Brand { get; set; }
    public string Tags { get; set; }
    public int CategoryId { get; set; }
    public IFormFile Thumbnail { get; set; }
    public IFormFileCollection Photos { get; set; }
}