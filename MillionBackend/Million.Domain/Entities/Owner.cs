using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Domain.Entities;

public class Owner
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Photo { get; set; }
    public required string BirthDate { get; set; }
}