
namespace MP.Domain.Ingredients
{
    public interface IIngredientsDomain
    {
        Task DeleteIngredientAsyncDomain(string id);
        Task<List<IngredientModel>> GetAllIngredientsDomain();
        Task<IngredientModel> GetIngredientByIdDomain(string id);
        Task<IngredientModel> PostIngredientAsyncDomain(IngredientModel model);
        Task UpdateIngredientAsyncDomain(IngredientModel model);
    }
}