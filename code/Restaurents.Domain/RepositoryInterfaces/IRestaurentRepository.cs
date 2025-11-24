using System;
using Restaurents.Application.Common;
using Restaurents.Domain.Entities;

namespace Restaurents.Infrastructure.Repositories.Interfaces;

public interface IRestaurentRepository
{
    Task<(IEnumerable<Restaurent>, int)> GetAllRestaurents(string? searchPhrase, int PageSize, int PageNumber, string? SortBy, SortDirection SortDirection);
    Task<Restaurent> GetRestaurentById(int id);
    Task<int> CreateRestaurent(Restaurent restaurent);
    Task<bool> DeleteRestaurent(Restaurent entity);
    Task<Restaurent?> UpdateRestaurent(Restaurent entity);
    Task<bool> SaveChanges();

}
