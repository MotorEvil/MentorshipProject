
namespace MP.AppServices.Services
{
    public interface IRecipeIngredientService
    {
        Task CreateRecipeIngredient(RecipeIngredientModel recipeIngredient);
        Task DeleteRecipeIngredient(string id);
        Task<RecipeIngredientModel> FindRecipeIngredientById(string id);
        Task<List<RecipeIngredientModel>> GetAllRecipeIngredients();
        Task UpdateRecipeIngredient(RecipeIngredientModel recipeIngredient);
    }
}