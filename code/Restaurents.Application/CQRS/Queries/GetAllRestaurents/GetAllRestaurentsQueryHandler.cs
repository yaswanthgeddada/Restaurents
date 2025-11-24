using System;
using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurents.Application.Common;
using Restaurents.Application.DTOs;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.Queries.GetAllRestaurents;

public class GetAllRestaurentsQueryHandler(IRestaurentRepository _repo, IMapper _mapper, ILogger<GetAllRestaurentsQueryHandler> _logger) : IRequestHandler<GetAllRestaurentsQuery, PageResult<RestaurentDto>>
{
    public async Task<PageResult<RestaurentDto>> Handle(GetAllRestaurentsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Inside Service layer - GetAllRestaurentsQueryHandler , Request object is - {JsonSerializer.Serialize(request)}");
        var (restaurent, totalCount) = await _repo.GetAllRestaurents(request?.searchPhrase, request.PageSize, request.PageNumber, request.SortBy, request.SortDirection);
        var resMapped = _mapper.Map<IEnumerable<RestaurentDto>>(restaurent);
        _logger.LogInformation($"mapping the resources to DTo - {resMapped}");

        var result = new PageResult<RestaurentDto>(resMapped, totalCount, request.PageSize, request.PageNumber);
        return result;
    }
}
