namespace MP.Data.Models;

public class IngredientModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public long CaloriesPer100 { get; set; }

}
