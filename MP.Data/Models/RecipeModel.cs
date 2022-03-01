namespace MP.Data.Models;

public class RecipeModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientModel> Ingredients { get; set; }
}
