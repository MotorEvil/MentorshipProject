namespace MP.AppServices.Services;

public class MealService : IMealService
{
    private readonly IMongoCollection<MealModel> _meals;

    public MealService(IAppDbConnection db)
    {
        _meals = db.MealCollection;
    }

    public Task CreateMeal(MealModel meal)
    {
        return _meals.InsertOneAsync(meal);
    }

    public async Task<List<MealModel>> GetAllMealsAsync()
    {
        var result = await _meals.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<MealModel> GetMealById(string id)
    {
        var result = await _meals.FindAsync(x => x.Id == id);
        return result.FirstOrDefault();
    }

    public Task UpdateMeal(MealModel meal)
    {
        var filter = Builders<MealModel>.Filter.Eq("Id", meal.Id);
        return _meals.ReplaceOneAsync(filter, meal, new ReplaceOptions { IsUpsert = true });
    }

    public async Task DeleteMeal(string id)
    {
        await _meals.DeleteOneAsync(x => x.Id == id);
    }
}
