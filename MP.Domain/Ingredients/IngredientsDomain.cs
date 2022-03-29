namespace MP.Domain.Ingredients;

public class IngredientsDomain : IIngredientsDomain
{
    private readonly IIngredientService _ingredients;

    public IngredientsDomain(IIngredientService ingredients)
    {
        _ingredients = ingredients;
    }

    public async Task<List<IngredientModel>> GetAllIngredientsDomain()
    {
        return await _ingredients.GetIngredientsAsync();
    }

    public Task<IngredientModel> GetIngredientByIdDomain(string id)
    {
        return _ingredients.FindIngredientById(id);
    }

    public async Task<IngredientModel> PostIngredientAsyncDomain(IngredientModel model)
    {
        await _ingredients.CreateIngredient(model);
        return model;
    }

    public async Task UpdateIngredientAsyncDomain(IngredientModel model)
    {
        await _ingredients.UpdateIngredient(model);
    }

    public async Task DeleteIngredientAsyncDomain(string id)
    {
        await _ingredients.DeleteIngredient(id);
    }
}
