namespace MP.AppServices.Services;

public class RecipeIngredientService : IRecipeIngredientService
{
    private readonly IMongoCollection<RecipeIngredientModel> _recipeIngredients;

    public RecipeIngredientService(IAppDbConnection db)
    {
        _recipeIngredients = db.RecipeIngrediantCollection;
    }

    public Task CreateRecipeIngredient(RecipeIngredientModel recipeIngredient)
    {
        return _recipeIngredients.InsertOneAsync(recipeIngredient);
    }

    public async Task<List<RecipeIngredientModel>> GetAllRecipeIngredients()
    {
        var result = await _recipeIngredients.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<RecipeIngredientModel> FindRecipeIngredientById(string id)
    {
        var recipeIngredient = await _recipeIngredients.FindAsync(x => x.Id == id);
        return recipeIngredient.FirstOrDefault();
    }

    public Task UpdateRecipeIngredient(RecipeIngredientModel recipeIngredient)
    {
        var filter = Builders<RecipeIngredientModel>.Filter.Eq("Id", recipeIngredient.Id);
        return _recipeIngredients.ReplaceOneAsync(filter, recipeIngredient, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteRecipeIngredient(string id)
    {
        return _recipeIngredients.DeleteOneAsync(x => x.Id == id);
    }

}
