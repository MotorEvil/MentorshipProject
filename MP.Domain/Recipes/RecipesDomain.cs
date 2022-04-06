namespace MP.Domain.Recipes;

public class RecipesDomain : IRecipesDomain
{
    private readonly IRecipeService _recipes;
    private readonly IRecipeIngredientService _recipeIngredients;
    public RecipesDomain(IRecipeService recipes,
                         IRecipeIngredientService recipeIngredient)
    {
        _recipes = recipes;
        _recipeIngredients = recipeIngredient;
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
        List<RecipeIngredientModel> recipeIngredientList = new List<RecipeIngredientModel>();

        foreach (var item in recipe.RecipeIngredients)
        {

            await _recipeIngredients.CreateRecipeIngredient(item);

            recipeIngredientList.Add(new RecipeIngredientModel
            {
                Id = item.Id,
                RecipeId = item.RecipeId,
                IngredientId = item.IngredientId,
                Quantity = item.Quantity
            });

        }

        RecipeModel model = new()
        {
            Name = recipe.Name,
            Description = recipe.Description,
            RecipeIngredients = recipeIngredientList
        };

        await _recipes.Createrecipe(model);

        foreach (var item in model.RecipeIngredients)
        {
            RecipeIngredientModel recipeIngredientModel = new()
            {
                Id=item.Id,
                RecipeId = model.Id,
                IngredientId=item.IngredientId,
                Quantity=item.Quantity
            };

            await _recipeIngredients.UpdateRecipeIngredient(recipeIngredientModel);
        };

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
