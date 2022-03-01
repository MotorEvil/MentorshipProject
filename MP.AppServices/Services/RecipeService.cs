namespace MP.AppServices.Services;

public class RecipeService : IRecipeService
{
    private readonly IMongoCollection<RecipeModel> _recipes;

    public RecipeService(IAppDbConnection db)
    {
        _recipes = db.RecipeCollection;
    }

    public Task Createrecipe(RecipeModel recipe)
    {
        return _recipes.InsertOneAsync(recipe);
    }

    public async Task<List<RecipeModel>> GetRecipeAsync()
    {
        var result = await _recipes.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<RecipeModel> FindRecipeById(string id)
    {
        var ingredient = await _recipes.FindAsync(x => x.Id == id);
        return ingredient.FirstOrDefault();
    }

    public Task UpdateRecipe(RecipeModel recipe)
    {
        var filter = Builders<RecipeModel>.Filter.Eq("Id", recipe.Id);
        return _recipes.ReplaceOneAsync(filter, recipe, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteRecipe(string id)
    {
        return _recipes.DeleteOneAsync(x => x.Id == id);
    }
}
