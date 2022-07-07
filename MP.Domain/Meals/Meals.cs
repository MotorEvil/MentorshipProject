namespace MP.Domain.Meals;

public class Meals : IMeals
{
    private readonly IMealService _meals;
    private readonly IRecipeService _recipes;

    public Meals(IMealService meals,
                       IRecipeService recipes)
    {
        _meals = meals;
        _recipes = recipes;
    }

    public async Task<List<MealModel>> GetAllMeals()
    {
        return await _meals.GetAllMealsAsync();
    }

    public Task<MealModel> GetMealById(string id)
    {
        return _meals.GetMealById(id);
    }

    public async Task<MealModel> PostMealAsync(MealModel model)
    {
        await _meals.CreateMeal(model);
        return model;
    }

    public async Task UpdateMealAsync(MealModel model)
    {
        await _meals.UpdateMeal(model);
    }

    public async Task DeleteMealAsync(string id)
    {
        await _meals.DeleteMeal(id);
    }
}
