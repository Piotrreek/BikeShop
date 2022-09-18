using Microsoft.AspNetCore.Identity;

namespace BikeShop.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}