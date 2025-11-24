using System;
using FluentValidation;
using Restaurents.Application.DTOs;
using Restaurents.Application.Queries.GetAllRestaurents;

namespace Restaurents.Application.CQRS.Queries.GetAllRestaurents;

public class GetAllRestaurentsQueryValidator : AbstractValidator<GetAllRestaurentsQuery>
{
    private int[] pageSizes = [5, 10, 30];
    private string[] allowedSortByColumnNames = [nameof(RestaurentDto.Name), nameof(RestaurentDto.Category), nameof(RestaurentDto.Description)];
    public GetAllRestaurentsQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThan(0);
        RuleFor(r => r.PageSize).Must(v => pageSizes.Contains(v))
        .WithMessage($"Page Size must be in [{string.Join(",", pageSizes)}]");

        RuleFor(r => r.SortBy)
            .Must(value => allowedSortByColumnNames.Contains(value))
            .When(q => q.SortBy != null)
            .WithMessage($"Sorting must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
