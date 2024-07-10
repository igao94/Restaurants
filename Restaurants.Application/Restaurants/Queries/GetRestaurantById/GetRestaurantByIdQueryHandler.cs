﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(
    IRestaurantsRepository restaurantsRepository,
    ILogger<GetRestaurantByIdQueryHandler> logger,
    IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant with id: {RestaurantId}.", request.Id);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        return mapper.Map<RestaurantDto>(restaurant);
    }
}
