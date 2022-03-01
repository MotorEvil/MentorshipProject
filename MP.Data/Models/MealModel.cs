namespace MP.Data.Models;

public class MealModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public RecipeModel Recipe { get; set; }
    public UserModel User { get; set; }

}
