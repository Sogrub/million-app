using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Domain.Entities;

public class PropertyTrace
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public required string Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)] 
    public required string PropertyId { get; set; }
    public required string DateSale { get; set; }
    public required string Name { get; set; }
    public int Value { get; set; }
    public int Tax { get; set; }
}