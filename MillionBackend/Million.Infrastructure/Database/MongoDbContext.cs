using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Million.Domain.Entities;

namespace Million.Infrastructure.Database;

public class MongoDbContext : IMongoDbContext
{
    public IMongoDatabase Database { get; }

    public MongoDbContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var dbName = config["DatabaseSettings:DatabaseName"];
        Database = client.GetDatabase(dbName);
    }

    public IMongoCollection<Property> Properties => Database.GetCollection<Property>("properties");
    public IMongoCollection<Owner> Owners => Database.GetCollection<Owner>("owners");
    public IMongoCollection<PropertyImage> PropertyImages => Database.GetCollection<PropertyImage>("propertyImages");
    public IMongoCollection<PropertyTrace> PropertyTraces => Database.GetCollection<PropertyTrace>("propertyTraces");
}