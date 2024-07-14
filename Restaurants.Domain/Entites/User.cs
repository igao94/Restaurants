using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entites;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality {  get; set; }
    public List<Restaurant> OwnedRestaurants { get; set; } = [];
}
