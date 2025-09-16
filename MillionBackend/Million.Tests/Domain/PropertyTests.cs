using FluentAssertions;
using Million.Domain.Entities;

namespace Million.Tests.Domain;

[TestFixture]
public class PropertyTests
{
    [Test]
    public void Property_Constructor_WithValidData_ShouldCreateProperty()
    {
        // Arrange
        var id = "507f1f77bcf86cd799439011";
        var idOwner = "507f1f77bcf86cd799439012";
        var name = "Casa en el centro";
        var address = "Calle Principal 123";
        var price = 250000m;

        // Act
        var property = new Property
        {
            Id = id,
            IdOwner = idOwner,
            Name = name,
            AddressProperty = address,
            PriceProperty = price
        };

        // Assert
        property.Should().NotBeNull();
        property.Id.Should().Be(id);
        property.IdOwner.Should().Be(idOwner);
        property.Name.Should().Be(name);
        property.AddressProperty.Should().Be(address);
        property.PriceProperty.Should().Be(price);
    }

    [Test]
    public void Property_WithEmptyId_ShouldAcceptEmptyId()
    {
        // Arrange & Act
        var property = new Property
        {
            Id = "",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa en el centro",
            AddressProperty = "Calle Principal 123",
            PriceProperty = 250000m
        };

        // Assert
        property.Id.Should().Be("");
        property.Should().NotBeNull();
    }

    [Test]
    public void Property_WithNegativePrice_ShouldAcceptNegativePrice()
    {
        // Arrange & Act
        var property = new Property
        {
            Id = "507f1f77bcf86cd799439011",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa en el centro",
            AddressProperty = "Calle Principal 123",
            PriceProperty = -1000m // Precio negativo
        };

        // Assert
        property.PriceProperty.Should().Be(-1000m);
    }

    [Test]
    public void Property_WithZeroPrice_ShouldAcceptZeroPrice()
    {
        // Arrange & Act
        var property = new Property
        {
            Id = "507f1f77bcf86cd799439011",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa en el centro",
            AddressProperty = "Calle Principal 123",
            PriceProperty = 0m
        };

        // Assert
        property.PriceProperty.Should().Be(0m);
    }

    [Test]
    public void Property_WithHighPrice_ShouldAcceptHighPrice()
    {
        // Arrange & Act
        var property = new Property
        {
            Id = "507f1f77bcf86cd799439011",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Mansión de lujo",
            AddressProperty = "Avenida Premium 999",
            PriceProperty = 999999999.99m
        };

        // Assert
        property.PriceProperty.Should().Be(999999999.99m);
    }

    [Test]
    public void Property_WithSpecialCharactersInName_ShouldAcceptSpecialCharacters()
    {
        // Arrange & Act
        var property = new Property
        {
            Id = "507f1f77bcf86cd799439011",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con ñ y acentos áéíóú",
            AddressProperty = "Calle Principal 123",
            PriceProperty = 250000m
        };

        // Assert
        property.Name.Should().Be("Casa con ñ y acentos áéíóú");
    }

    [Test]
    public void Property_WithLongAddress_ShouldAcceptLongAddress()
    {
        // Arrange
        var longAddress = new string('A', 1000); // Dirección muy larga

        // Act
        var property = new Property
        {
            Id = "507f1f77bcf86cd799439011",
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa en el centro",
            AddressProperty = longAddress,
            PriceProperty = 250000m
        };

        // Assert
        property.AddressProperty.Should().Be(longAddress);
        property.AddressProperty.Length.Should().Be(1000);
    }

    [Test]
    public void Property_WithRequiredFields_ShouldCreateProperty()
    {
        // Arrange & Act
        var property = new Property
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa Test",
            AddressProperty = "Dirección Test",
            PriceProperty = 100000m
        };

        // Assert
        property.Should().NotBeNull();
        property.IdOwner.Should().Be("507f1f77bcf86cd799439012");
        property.Name.Should().Be("Casa Test");
        property.AddressProperty.Should().Be("Dirección Test");
        property.PriceProperty.Should().Be(100000m);
    }
}