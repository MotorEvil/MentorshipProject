namespace MP.Data.Models;

public class CategorieModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string? ParentId { get; set; }
}
