using Restaurants.Domain.Entites;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> CreateAsync(Dish dish);
    Task DeleteAsync(IEnumerable<Dish> dishes);
}
