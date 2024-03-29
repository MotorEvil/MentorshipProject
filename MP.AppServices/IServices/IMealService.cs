﻿
namespace MP.AppServices.Services
{
    public interface IMealService
    {
        Task CreateMeal(MealModel meal);
        Task DeleteMeal(string id);
        Task<List<MealModel>> GetAllMealsAsync();
        Task<MealModel> GetMealById(string id);
        Task UpdateMeal(MealModel meal);
    }
}