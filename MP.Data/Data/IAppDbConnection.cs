
namespace MP.Data.Data
{
    public interface IAppDbConnection
    {
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<IngredientModel> IngredientCollection { get; }
        string IngredientCollectionName { get; }
        IMongoCollection<RecipeModel> RecipeCollection { get; }
        string RecipeCollectionName { get; }
        IMongoCollection<MealModel> MealCollection { get; }
        string MealCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
        IMongoCollection<RecipeIngredientModel> RecipeIngrediantCollection { get; }
        string RecipeIngrediantCollectionName { get; }
        IMongoCollection<CategorieModel> CategorieCollection { get; }
        string CategorieCollectionName { get; }
    }
}