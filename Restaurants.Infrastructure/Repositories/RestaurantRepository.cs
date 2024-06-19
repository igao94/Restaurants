using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Data;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository(AppDbContext context) : IRestaurantsRepository
{
    public async Task<int> CreateAsync(Restaurant restaurant)
    {
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        return await context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        return await context.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
