namespace MP.Domain.Meals;

public class MealsDomain : IMealsDomain
{
    private readonly IMealService _meals;
    private readonly IRecipeService _recipes;

    public MealsDomain(IMealService meals,
                       IRecipeService recipes)
    {
        _meals = meals;
        _recipes = recipes;
    }

    public async Task<List<MealModel>> GetAllMealsDomain()
    {
        return await _meals.GetAllMealsAsync();
    }

    public Task<MealModel> GetMealByIdDomain(string id)
    {
        return _meals.GetMealById(id);
    }

    public async Task<MealModel> PostMealAsyncDomain(MealModel model)
    {
        await _meals.CreateMeal(model);
        return model;
    }

    public async Task UpdateMealAsyncDomain(MealModel model)
    {
        await _meals.UpdateMeal(model);
    }

    public async Task DeleteMealAsyncDomain(string id)
    {
        await _meals.DeleteMeal(id);
    }
}
