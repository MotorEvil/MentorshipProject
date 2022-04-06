namespace MP.Data.Models;

public class RecipeIngredientModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string RecipeId { get; set; }
    public string IngredientId { get; set; }
    public float Quantity { get; set; }
}
