using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurents.Application.Common;
using Restaurents.Application.DTOs;

namespace Restaurents.Application.Queries.GetAllRestaurents;

public class GetAllRestaurentsQuery() : IRequest<PageResult<RestaurentDto>>
{
    public string? searchPhrase { get; set; }
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }

}
