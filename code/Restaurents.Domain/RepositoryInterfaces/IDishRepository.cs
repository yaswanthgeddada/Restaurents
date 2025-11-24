using System;
using Restaurents.Domain.Entities;

namespace Restaurents.Domain.RepositoryInterfaces;

public interface IDishRepository
{
    Task<Dish> CreateDish(Dish dish);
    // Task<Dish> GetDishById(Dish dish);
    Task<IEnumerable<Dish>> GetAllDishes(int restId);
    Task<Dish> GetDishById(int restId, int DishId);
    Task<bool> DeleteDish(int restId);
}
