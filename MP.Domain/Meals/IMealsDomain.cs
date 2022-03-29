
namespace MP.Domain.Meals
{
    public interface IMealsDomain
    {
        Task DeleteMealAsyncDomain(string id);
        Task<List<MealModel>> GetAllMealsDomain();
        Task<MealModel> GetMealByIdDomain(string id);
        Task<MealModel> PostMealAsyncDomain(MealModel model);
        Task UpdateMealAsyncDomain(MealModel model);
    }
}