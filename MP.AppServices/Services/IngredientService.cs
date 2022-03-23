namespace MP.AppServices.Services;

public class IngredientService : IIngredientService
{
    private readonly IMongoCollection<IngredientModel> _ingredients;

    public IngredientService(IAppDbConnection db)
    {
        _ingredients = db.IngredientCollection;
    }

    public Task CreateIngredient(IngredientModel ingredient)
    {
        return _ingredients.InsertOneAsync(ingredient);
    }
    public async Task<List<IngredientModel>> GetIngredientsAsync()
    {
        var result = await _ingredients.FindAsync(_ => true);
        return result.ToList();
    }

    public string FindIngredientByName(string name)
    {
        var ingredients = _ingredients.Find(x => x.Name == name).ToList();
        return ingredients.FirstOrDefault()?.Id;

    }

    public async Task<IngredientModel> FindIngredientById(string id)
    {
        var ingredient = await _ingredients.FindAsync(x => x.Id == id);
        return ingredient.FirstOrDefault();
    }

    public Task UpdateIngredient(IngredientModel ingredient)
    {
        var filter = Builders<IngredientModel>.Filter.Eq("Id", ingredient.Id);
        return _ingredients.ReplaceOneAsync(filter, ingredient, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteIngredient(string id)
    {
        return _ingredients.DeleteOneAsync(x => x.Id == id);
    }

}
