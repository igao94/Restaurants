using Restaurants.Domain.Constants;
using Restaurants.Domain.Entites;

namespace Restaurants.Domain.Interfaces;

public interface IRestaurantAuthorizationService
{
    bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation);
}