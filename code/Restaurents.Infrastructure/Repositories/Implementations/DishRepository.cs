using System;
using Microsoft.EntityFrameworkCore;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;
using Restaurents.Domain.RepositoryInterfaces;
using Restaurents.Infrastructure.Persistance;

namespace Restaurents.Infrastructure.Repositories.Implementations;

public class DishRepository(RestaurentDbContext _context) : IDishRepository
{
    public async Task<Dish> CreateDish(Dish dish)
    {
        await _context.Dishes.AddAsync(dish);
        await _context.SaveChangesAsync();

        return dish;
    }

    public async Task<bool> DeleteDish(int restId)
    {
        _context.Remove(restId);
        var res = await _context.SaveChangesAsync();
        if (res > 0)
        {
            return true;
        }
        else return false;
    }

    public async Task<IEnumerable<Dish>> GetAllDishes(int restId)
    {
        var dishes = await _context.Dishes.Where(d => d.RestaurentId == restId).ToListAsync();
        return dishes;
    }

    public async Task<Dish> GetDishById(int restId, int DishId)
    {
        var restaurent = await _context.Restaurents.FindAsync(restId);

        if (restaurent == null)
        {
            throw new NotFoundException($"Restaurent not found {restId}");
        }

        var dish = await _context.Dishes.FindAsync(DishId);

        if (dish == null)
        {
            throw new NotFoundException($"dish not found {restId}");
        }

        return dish;
    }
}
