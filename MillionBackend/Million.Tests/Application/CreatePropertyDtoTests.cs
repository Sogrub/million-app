using FluentAssertions;
using Million.Application.DTOs;

namespace Million.Tests.Application;

[TestFixture]
public class CreatePropertyDtoTests
{
    [Test]
    public void CreatePropertyDto_Constructor_WithValidData_ShouldCreateCreatePropertyDto()
    {
        // Arrange
        var idOwner = "507f1f77bcf86cd799439012";
        var name = "Casa en el centro";
        var addressProperty = "Calle Principal 123";
        var priceProperty = 250000m;
        var image = "casa-centro.jpg";

        // Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = idOwner,
            Name = name,
            AddressProperty = addressProperty,
            PriceProperty = priceProperty,
            Image = image
        };

        // Assert
        createPropertyDto.Should().NotBeNull();
        createPropertyDto.IdOwner.Should().Be(idOwner);
        createPropertyDto.Name.Should().Be(name);
        createPropertyDto.AddressProperty.Should().Be(addressProperty);
        createPropertyDto.PriceProperty.Should().Be(priceProperty);
        createPropertyDto.Image.Should().Be(image);
    }

    [Test]
    public void CreatePropertyDto_WithRequiredFields_ShouldCreateCreatePropertyDto()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa Test",
            AddressProperty = "Dirección Test",
            PriceProperty = 100000m,
            Image = "casa-test.jpg"
        };

        // Assert
        createPropertyDto.Should().NotBeNull();
        createPropertyDto.IdOwner.Should().Be("507f1f77bcf86cd799439012");
        createPropertyDto.Name.Should().Be("Casa Test");
        createPropertyDto.AddressProperty.Should().Be("Dirección Test");
        createPropertyDto.PriceProperty.Should().Be(100000m);
        createPropertyDto.Image.Should().Be("casa-test.jpg");
    }

    [Test]
    public void CreatePropertyDto_WithZeroPrice_ShouldAcceptZeroPrice()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa gratis",
            AddressProperty = "Calle Gratuita 123",
            PriceProperty = 0m,
            Image = "casa-gratis.jpg"
        };

        // Assert
        createPropertyDto.PriceProperty.Should().Be(0m);
    }

    [Test]
    public void CreatePropertyDto_WithNegativePrice_ShouldAcceptNegativePrice()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con descuento",
            AddressProperty = "Calle Descuento 456",
            PriceProperty = -10000m,
            Image = "casa-descuento.jpg"
        };

        // Assert
        createPropertyDto.PriceProperty.Should().Be(-10000m);
    }

    [Test]
    public void CreatePropertyDto_WithHighPrice_ShouldAcceptHighPrice()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Mansión de lujo",
            AddressProperty = "Avenida Premium 999",
            PriceProperty = 999999999.99m,
            Image = "mansión-lujo.jpg"
        };

        // Assert
        createPropertyDto.PriceProperty.Should().Be(999999999.99m);
    }

    [Test]
    public void CreatePropertyDto_WithSpecialCharactersInName_ShouldAcceptSpecialCharacters()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con ñ y acentos áéíóú",
            AddressProperty = "Calle Especial 789",
            PriceProperty = 300000m,
            Image = "casa-especial.jpg"
        };

        // Assert
        createPropertyDto.Name.Should().Be("Casa con ñ y acentos áéíóú");
    }

    [Test]
    public void CreatePropertyDto_WithLongAddress_ShouldAcceptLongAddress()
    {
        // Arrange
        var longAddress = new string('A', 500);

        // Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con dirección larga",
            AddressProperty = longAddress,
            PriceProperty = 200000m,
            Image = "casa-larga.jpg"
        };

        // Assert
        createPropertyDto.AddressProperty.Should().Be(longAddress);
        createPropertyDto.AddressProperty.Length.Should().Be(500);
    }

    [Test]
    public void CreatePropertyDto_WithValidIdOwner_ShouldAcceptIdOwner()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439999",
            Name = "Casa nueva",
            AddressProperty = "Calle Nueva 321",
            PriceProperty = 150000m,
            Image = "casa-nueva.jpg"
        };

        // Assert
        createPropertyDto.IdOwner.Should().Be("507f1f77bcf86cd799439999");
    }

    [Test]
    public void CreatePropertyDto_WithImageUrl_ShouldAcceptImageUrl()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con imagen URL",
            AddressProperty = "Calle URL 654",
            PriceProperty = 180000m,
            Image = "https://example.com/images/properties/casa-url.jpg"
        };

        // Assert
        createPropertyDto.Image.Should().Be("https://example.com/images/properties/casa-url.jpg");
    }

    [Test]
    public void CreatePropertyDto_WithBase64Image_ShouldAcceptBase64Image()
    {
        // Arrange
        var base64Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD...";

        // Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "507f1f77bcf86cd799439012",
            Name = "Casa con imagen base64",
            AddressProperty = "Calle Base64 987",
            PriceProperty = 220000m,
            Image = base64Image
        };

        // Assert
        createPropertyDto.Image.Should().Be(base64Image);
    }

    [Test]
    public void CreatePropertyDto_WithEmptyStringFields_ShouldAcceptEmptyStrings()
    {
        // Arrange & Act
        var createPropertyDto = new CreatePropertyDto
        {
            IdOwner = "",
            Name = "",
            AddressProperty = "",
            PriceProperty = 0m,
            Image = ""
        };

        // Assert
        createPropertyDto.IdOwner.Should().Be("");
        createPropertyDto.Name.Should().Be("");
        createPropertyDto.AddressProperty.Should().Be("");
        createPropertyDto.Image.Should().Be("");
    }
}
