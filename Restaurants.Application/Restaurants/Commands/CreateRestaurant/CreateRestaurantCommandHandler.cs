using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserEmail} [{UserId}] is creating a new restaurant {@Restaurant}.",
            currentUser!.Email, currentUser.Id, request);
        var restaurant = mapper.Map<Restaurant>(request);

        restaurant.OwnerId = currentUser.Id;

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Create))
            throw new ForbidException();

        return await restaurantsRepository.CreateAsync(restaurant);
    }
}
