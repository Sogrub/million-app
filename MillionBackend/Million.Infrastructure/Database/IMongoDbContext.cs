using MongoDB.Driver;
using Million.Domain.Entities;

namespace Million.Infrastructure.Database;

public interface IMongoDbContext
{
    IMongoDatabase Database { get; }
    IMongoCollection<Property> Properties { get; }
    IMongoCollection<Owner> Owners { get; }
    IMongoCollection<PropertyImage> PropertyImages { get; }
    IMongoCollection<PropertyTrace> PropertyTraces { get; }
}
