using System;
using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurents.Application.Common;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;
using Restaurents.Infrastructure.Persistance;
using Restaurents.Infrastructure.Repositories.Interfaces;
using SQLitePCL;

namespace Restaurents.Infrastructure.Repositories.Implementations;

public class RestaurentRepository : IRestaurentRepository
{
    private readonly RestaurentDbContext _context;
    private readonly ILogger _logger;

    public RestaurentRepository(RestaurentDbContext context, ILogger<RestaurentRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> CreateRestaurent(Restaurent restaurent)
    {
        await _context.Restaurents.AddAsync(restaurent);
        await _context.SaveChangesAsync();
        return restaurent.Id;
    }

    public async Task<bool> DeleteRestaurent(Restaurent entity)
    {
        _context.Restaurents.Remove(entity);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<(IEnumerable<Restaurent>, int)> GetAllRestaurents(string? searchPhrase, int PageSize, int PageNumber, string? SortBy, SortDirection SortDirection)
    {
        _logger.LogInformation("Inside Infra layer GetAllRestaurents called");

        var query = _context.Restaurents
                                        .Where(r =>
                                        searchPhrase == null ||
                                        r.Name.ToLower().Contains(searchPhrase.ToLower())
                                        || r.Name.ToLower().Contains(searchPhrase.ToLower()));

        var totalCount = await query.CountAsync();

        if (SortBy != null)
        {
            var columnSelector = new Dictionary<string, Expression<Func<Restaurent, object>>>
            {
                {nameof(Restaurent.Name), r=>r.Name},
                {nameof(Restaurent.Description), r=>r.Description},
                {nameof(Restaurent.Category), r=>r.Category},
            };

            var selectedColumn = columnSelector[SortBy];

            query = SortDirection == SortDirection.Ascending ?
                                            query.OrderBy(selectedColumn) : query.OrderByDescending(selectedColumn);
        }

        var restaurents = await query
                                    .Skip(PageSize * (PageNumber - 1))
                                    .Take(PageSize)
                                    .ToListAsync();

        _logger.LogInformation($"Response from DB call - {JsonSerializer.Serialize(restaurents)}");

        if (restaurents.Count == 0 && !restaurents.Any())
        {
            throw new NotFoundException($"List is empty or No restaurents found");
        }

        return (restaurents, totalCount);
    }

    public async Task<Restaurent> GetRestaurentById(int id)
    {
        try
        {
            var restaurent = await _context.Restaurents.Include(d => d.Dishes).FirstOrDefaultAsync(s => s.Id == id);

            if (restaurent != null)
                return restaurent;

            else throw new NotFoundException($"Record ({id})  Not found");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Restaurent?> UpdateRestaurent(Restaurent entity)
    {
        try
        {
            var record = await _context.Restaurents.FindAsync(entity.Id);

            if (record == null)
            {
                throw new NotFoundException($"Record ({entity.Id}) Not found");
            }

            record = entity;
            var result = await _context.SaveChangesAsync();
            return record;


        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> SaveChanges() => await _context.SaveChangesAsync() > 0;
}
