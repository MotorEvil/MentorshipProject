namespace MP.Data.Models;

public class RecipeCategoryModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public List<RecipeModel> Recipes { get; set; }
}
