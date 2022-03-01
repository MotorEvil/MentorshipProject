namespace MP.Data.Models;

public class RecipeIngredientModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public RecipeModel Recipe { get; set; }
    public IngredientModel Ingredient { get; set; }
    public float Quantity { get; set; }
    public List<RecipeCategoryModel> Category { get; set; }
}
