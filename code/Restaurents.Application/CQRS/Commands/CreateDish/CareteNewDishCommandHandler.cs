using System;
using AutoMapper;
using MediatR;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;
using Restaurents.Domain.RepositoryInterfaces;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.CQRS.Commands.CreateDish;

public class CareteNewDishCommandHandler(IDishRepository _dishRepo, IRestaurentRepository _restaurentRepo, IMapper _mapper) : IRequestHandler<CraeteNewDishCommand, Dish>
{
    public async Task<Dish> Handle(CraeteNewDishCommand request, CancellationToken cancellationToken)
    {
        var restaurent = await _restaurentRepo.GetRestaurentById(request.RestaurentId);
        if (restaurent == null)
        {
            throw new NotFoundException($"Record with {request.RestaurentId} Not Found");
        }

        var mappedDish = _mapper.Map<Dish>(request);

        var response = await _dishRepo.CreateDish(mappedDish);

        return response;
    }
}
