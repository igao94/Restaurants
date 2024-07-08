using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;

namespace Restaurants.Infrastructure.Repositories;

internal class DishesRepository(AppDbContext context) : IDishesRepository
{
    public async Task<int> CreateAsync(Dish dish)
    {
        await context.Dishes.AddAsync(dish);
        await context.SaveChangesAsync();

        return dish.Id;
    }

    public async Task DeleteAsync(IEnumerable<Dish> dishes)
    {
        context.Dishes.RemoveRange(dishes);
        await context.SaveChangesAsync();
    }
}
