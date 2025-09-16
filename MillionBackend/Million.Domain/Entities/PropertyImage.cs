using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Domain.Entities;

public class PropertyImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)] 
    public required string PropertyId { get; set; }
    public required string Image { get; set; }
    public bool Enabled { get; set; }
}