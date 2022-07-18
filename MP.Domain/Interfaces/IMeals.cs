
namespace MP.Domain.Meals
{
    public interface IMeals
    {
        Task DeleteMealAsync(string id);
        Task<List<MealModel>> GetAllMeals();
        Task<MealModel> GetMealById(string id);
        Task<MealModel> PostMealAsync(MealModel model);
        Task UpdateMealAsync(MealModel model);
    }
}