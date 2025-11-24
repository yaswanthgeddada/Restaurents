using System;
using AutoMapper;
using MediatR;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.Commands.UpdateRestaurent;

public class UpdateRestaurentCommandHandler(IMapper _mapper, IRestaurentRepository _repo) : IRequestHandler<UpdateRestaurentCommand, RestaurentDto>
{
    public async Task<RestaurentDto?> Handle(UpdateRestaurentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetRestaurentById(request.Id);
        _mapper.Map(request, entity);
        var res = await _repo.SaveChanges();
        var result = _mapper.Map<RestaurentDto>(entity);
        return res ? result : throw new Exception("failed to update");
    }
}
