
namespace MP.Domain.Interfaces
{
    public interface IIngredients
    {
        Task DeleteIngredientAsync(string id);
        Task<List<IngredientModel>> GetAllIngredients();
        Task<IngredientModel> GetIngredientById(string id);
        Task<IngredientModel> PostIngredientAsync(IngredientModel model);
        Task UpdateIngredientAsync(IngredientModel model);
    }
}