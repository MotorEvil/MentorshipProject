namespace MP.Domain.Ingredients;

public class Ingredients : IIngredients
{
    private readonly IIngredientService _ingredients;

    public Ingredients(IIngredientService ingredients)
    {
        _ingredients = ingredients;
    }

    public async Task<List<IngredientModel>> GetAllIngredients()
    {
        return await _ingredients.GetIngredientsAsync();
    }

    public Task<IngredientModel> GetIngredientById(string id)
    {
        return _ingredients.FindIngredientById(id);
    }

    public async Task<IngredientModel> PostIngredientAsync(IngredientModel model)
    {
        await _ingredients.CreateIngredient(model);
        return model;
    }

    public async Task UpdateIngredientAsync(IngredientModel model)
    {
        await _ingredients.UpdateIngredient(model);
    }

    public async Task DeleteIngredientAsync(string id)
    {
        await _ingredients.DeleteIngredient(id);
    }
}
