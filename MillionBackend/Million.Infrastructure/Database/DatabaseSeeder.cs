using Million.Domain.Entities;
using MongoDB.Driver;
using System.Text.Json;
using MongoDB.Bson.Serialization;

namespace Million.Infrastructure.Database;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IMongoDatabase database)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, "SeedData");

        await SeedCollectionIfEmptyAsync<Owner>(
            database.GetCollection<Owner>("owners"),
            Path.Combine(basePath, "owners.json")
        );

        await SeedCollectionIfEmptyAsync<Property>(
            database.GetCollection<Property>("properties"),
            Path.Combine(basePath, "properties.json")
        );

        await SeedCollectionIfEmptyAsync<PropertyImage>(
            database.GetCollection<PropertyImage>("propertyImages"),
            Path.Combine(basePath, "propertyImages.json")
        );

        await SeedCollectionIfEmptyAsync<PropertyTrace>(
            database.GetCollection<PropertyTrace>("propertyTraces"),
            Path.Combine(basePath, "propertyTraces.json")
        );
    }

  public static object SeedAsync(IMongoDbContext dbContext)
  {
    throw new NotImplementedException();
  }

  private static async Task SeedCollectionIfEmptyAsync<T>(
    IMongoCollection<T> collection,
    string filePath
  )
  {
    if (collection == null) return;
    if (!File.Exists(filePath)) return;

    var count = await collection.CountDocumentsAsync(Builders<T>.Filter.Empty);
    if (count > 0) return;

    var json = await File.ReadAllTextAsync(filePath);

    var items = BsonSerializer.Deserialize<List<T>>(json);

    if (items != null && items.Count > 0)
    {
        await collection.InsertManyAsync(items);
    }
  }
}
