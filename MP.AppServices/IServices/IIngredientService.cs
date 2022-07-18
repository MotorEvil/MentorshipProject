
namespace MP.AppServices.Services
{
    public interface IIngredientService
    {
        Task CreateIngredient(IngredientModel ingredient);
        string FindIngredientByName(string name);
        Task<List<IngredientModel>> GetIngredientsAsync();
        Task<IngredientModel> FindIngredientById(string id);
        Task UpdateIngredient(IngredientModel ingredient);
        Task DeleteIngredient(string id);
    }
}