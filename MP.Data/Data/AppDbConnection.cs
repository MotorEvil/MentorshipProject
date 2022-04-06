namespace MP.Data.Data;

public class AppDbConnection : IAppDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string   _connectionId = "MongoDB";

    public MongoClient Client { get; private set; }
    public string DbName { get; private set; }
    public string IngredientCollectionName { get; private set; }       = "ingredients";
    public string RecipeCollectionName { get; private set; }           = "recepes";
    public string MealCollectionName { get; private set; }             = "meals";
    public string UserCollectionName { get; private set; }             = "users";
    public string RecipeIngrediantCollectionName { get; private set; } = "RecipieIngredient";

    public IMongoCollection<RecipeModel> RecipeCollection { get; private set; }
    public IMongoCollection<IngredientModel> IngredientCollection { get; private set; }
    public IMongoCollection<MealModel> MealCollection { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<RecipeIngredientModel> RecipeIngrediantCollection { get; private set; }

    public AppDbConnection(IConfiguration config)
    {
        _config = config;
        Client  = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName  = _config["DatabaseName"];
        _db     = Client.GetDatabase(DbName);

        IngredientCollection       = _db.GetCollection<IngredientModel>(IngredientCollectionName);
        RecipeCollection           = _db.GetCollection<RecipeModel>(RecipeCollectionName);
        MealCollection             = _db.GetCollection<MealModel>(MealCollectionName);
        UserCollection             = _db.GetCollection<UserModel>(UserCollectionName);
        RecipeIngrediantCollection = _db.GetCollection<RecipeIngredientModel>(RecipeIngrediantCollectionName);
    }

}
