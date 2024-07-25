using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization.Requirements.CreatedMultipleRestaurants;

public class CreatedMultipleRestaurantsRequirement(int minimumRestaurantCreated)
    : IAuthorizationRequirement
{
    public int MinimumRestaurantCreated { get; } = minimumRestaurantCreated;
}
