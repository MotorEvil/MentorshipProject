namespace MP.AppServices.Services;

public interface IRecipeService
{
    Task Createrecipe(RecipeModel recipe);
    Task<List<RecipeModel>> GetRecipeAsync();
    Task<RecipeModel> FindRecipeById(string id);
    Task UpdateRecipe(RecipeModel recipe);
    Task DeleteRecipe(string id);
}
