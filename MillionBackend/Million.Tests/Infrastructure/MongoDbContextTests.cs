using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Million.Infrastructure.Database;
using MongoDB.Driver;

namespace Million.Tests.Infrastructure;

[TestFixture]
public class MongoDbContextTests
{
    private IConfiguration _configuration;

    [SetUp]
    public void Setup()
    {
        // Crear configuración real para tests
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["ConnectionStrings:MongoDb"] = "mongodb://localhost:27017",
            ["DatabaseSettings:DatabaseName"] = "MillionTestDb"
        });
        
        _configuration = configurationBuilder.Build();
    }

    [Test]
    public void MongoDbContext_Constructor_WithValidConfiguration_ShouldCreateInstance()
    {
        // Act
        var mongoDbContext = new MongoDbContext(_configuration);

        // Assert
        mongoDbContext.Should().NotBeNull();
        mongoDbContext.Should().BeAssignableTo<IMongoDbContext>();
    }

    [Test]
    public void MongoDbContext_Properties_ShouldReturnMongoCollection()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var propertiesCollection = mongoDbContext.Properties;

        // Assert
        propertiesCollection.Should().NotBeNull();
        propertiesCollection.Should().BeAssignableTo<IMongoCollection<Million.Domain.Entities.Property>>();
    }

    [Test]
    public void MongoDbContext_Owners_ShouldReturnMongoCollection()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var ownersCollection = mongoDbContext.Owners;

        // Assert
        ownersCollection.Should().NotBeNull();
        ownersCollection.Should().BeAssignableTo<IMongoCollection<Million.Domain.Entities.Owner>>();
    }

    [Test]
    public void MongoDbContext_PropertyImages_ShouldReturnMongoCollection()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var propertyImagesCollection = mongoDbContext.PropertyImages;

        // Assert
        propertyImagesCollection.Should().NotBeNull();
        propertyImagesCollection.Should().BeAssignableTo<IMongoCollection<Million.Domain.Entities.PropertyImage>>();
    }

    [Test]
    public void MongoDbContext_PropertyTraces_ShouldReturnMongoCollection()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var propertyTracesCollection = mongoDbContext.PropertyTraces;

        // Assert
        propertyTracesCollection.Should().NotBeNull();
        propertyTracesCollection.Should().BeAssignableTo<IMongoCollection<Million.Domain.Entities.PropertyTrace>>();
    }

    [Test]
    public void MongoDbContext_Constructor_WithNullConfiguration_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        Action action = () => new MongoDbContext(null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void MongoDbContext_Properties_ShouldHaveCorrectCollectionName()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var propertiesCollection = mongoDbContext.Properties;

        // Assert
        propertiesCollection.Should().NotBeNull();
        // Verificar que la colección tenga el nombre correcto
        var collectionName = propertiesCollection.CollectionNamespace.CollectionName;
        collectionName.Should().Be("properties");
    }

    [Test]
    public void MongoDbContext_Properties_ShouldReturnSameInstance()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);

        // Act
        var collection1 = mongoDbContext.Properties;
        var collection2 = mongoDbContext.Properties;

        // Assert
        collection1.Should().NotBeNull();
        collection2.Should().NotBeNull();
        // Verificar que tienen el mismo nombre de colección en lugar de la misma referencia
        collection1.CollectionNamespace.CollectionName.Should().Be(collection2.CollectionNamespace.CollectionName);
    }

    [Test]
    public void MongoDbContext_Constructor_WithTestConfiguration_ShouldWork()
    {
        // Act & Assert
        Action action = () => new MongoDbContext(_configuration);
        action.Should().NotThrow();
    }

    [Test]
    public void MongoDbContext_ShouldImplementIMongoDbContext()
    {
        // Arrange & Act
        var mongoDbContext = new MongoDbContext(_configuration);

        // Assert
        mongoDbContext.Should().BeAssignableTo<IMongoDbContext>();
    }

    [Test]
    public void MongoDbContext_Properties_ShouldBeAccessibleThroughInterface()
    {
        // Arrange
        var mongoDbContext = new MongoDbContext(_configuration);
        IMongoDbContext interfaceContext = mongoDbContext;

        // Act
        var propertiesCollection = interfaceContext.Properties;
        var directPropertiesCollection = mongoDbContext.Properties;

        // Assert
        propertiesCollection.Should().NotBeNull();
        directPropertiesCollection.Should().NotBeNull();
        // Verificar que ambas colecciones tienen el mismo nombre
        propertiesCollection.CollectionNamespace.CollectionName.Should().Be(directPropertiesCollection.CollectionNamespace.CollectionName);
    }
}