namespace MP.Domain.Recipes;

public interface IRecipes
{
    Task<List<RecipeModel>> GetAllRecipes();
    Task<RecipeModel> GetRecipeById(string id);
    Task<RecipeModel> RecipePostAsync(RecipeModel recipe);
    Task UpdateRecipeAsync(RecipeModel recipe);
    Task DeleleRecipeAsync(string id);
}
