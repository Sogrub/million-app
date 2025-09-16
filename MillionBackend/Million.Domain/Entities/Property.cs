using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.Domain.Entities;

public class Property
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdOwner { get; set; }
    public required string Name { get; set; }
    public required string AddressProperty { get; set; }
    public required string Type { get; set; }
    public decimal PriceProperty { get; set; }
    public string? Description { get; set; }
}
