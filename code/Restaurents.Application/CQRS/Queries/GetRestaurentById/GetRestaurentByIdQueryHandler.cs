using System;
using AutoMapper;
using MediatR;
using Restaurents.Application.DTOs;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.Queries.GetRestaurentById;

public class GetRestaurentByIdQueryHandler(IRestaurentRepository _repo, IMapper _mapper) : IRequestHandler<GetRestaurentByIdQuery, RestaurentDto?>
{
    public async Task<RestaurentDto?> Handle(GetRestaurentByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _repo.GetRestaurentById(request.Id);
        var resMapped = _mapper.Map<RestaurentDto>(res);
        return resMapped;
    }
}
