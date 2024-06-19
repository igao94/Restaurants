﻿using AutoMapper;
using Restaurants.Domain.Entites;

namespace Restaurants.Application.Dishes.DTO;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
