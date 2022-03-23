namespace MP.Domain.Recipes;

public class RecipesDomain : IRecipesDomain
{
    private readonly IRecipeService _recipes;
    private readonly IIngredientService _ingrediens;
    public RecipesDomain(IRecipeService recipes,
                         IIngredientService ingrediens)
    {
        _recipes = recipes;
        _ingrediens = ingrediens;
    }

    public async Task<List<RecipeModel>> GetAllRecipesDomain()
    {
        return await _recipes.GetRecipeAsync();
    }

    public Task<RecipeModel> GetRecipeByIdDomain(string id)
    {
        return _recipes.FindRecipeById(id);
    }

    public async Task<RecipeModel> RecipePostAsyncDomain(RecipeModel recipe)
    {
        List<IngredientModel> ingredientList = new List<IngredientModel>();

        foreach (var item in recipe.Ingredients)
        {

            var ingredient = _ingrediens.FindIngredientByName(item.Name);

            if (string.IsNullOrEmpty(ingredient))
            {
                await _ingrediens.CreateIngredient(item);

                ingredientList.Add(new IngredientModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CaloriesPer100 = item.CaloriesPer100
                });

            }
            else
            {
                IngredientModel ingModel = await _ingrediens.FindIngredientById(ingredient);

                ingredientList.Add(new IngredientModel
                {
                    Id = ingModel.Id,
                    Name = ingModel.Name,
                    CaloriesPer100 = ingModel.CaloriesPer100
                });

            }
        }

        RecipeModel model = new()
        {
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = ingredientList
        };

        await _recipes.Createrecipe(model);

        return recipe;
    }

    public async Task UpdateRecipeDomainAsync(RecipeModel recipe)
    {
        await _recipes.UpdateRecipe(recipe);
    }

    public async Task DeleleRecipeDomainAsync(string id)
    {
        await _recipes.DeleteRecipe(id);
    }
}
