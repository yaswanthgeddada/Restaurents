using System;
using AutoMapper;
using Restaurents.Application.CQRS.Commands.CreateDish;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.Profiles;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<CraeteNewDishCommand, Dish>();
    }
}
