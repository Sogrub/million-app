using FluentAssertions;
using Million.Domain.Entities;

namespace Million.Tests.Domain;

[TestFixture]
public class PropertyImageTests
{
    [Test]
    public void PropertyImage_Constructor_WithValidData_ShouldCreatePropertyImage()
    {
        // Arrange
        var id = "507f1f77bcf86cd799439011";
        var propertyId = "507f1f77bcf86cd799439012";
        var image = "property-image.jpg";
        var enabled = true;

        // Act
        var propertyImage = new PropertyImage
        {
            Id = id,
            PropertyId = propertyId,
            Image = image,
            Enabled = enabled
        };

        // Assert
        propertyImage.Should().NotBeNull();
        propertyImage.Id.Should().Be(id);
        propertyImage.PropertyId.Should().Be(propertyId);
        propertyImage.Image.Should().Be(image);
        propertyImage.Enabled.Should().Be(enabled);
    }

    [Test]
    public void PropertyImage_WithRequiredFields_ShouldCreatePropertyImage()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = "house-front.jpg",
            Enabled = true
        };

        // Assert
        propertyImage.Should().NotBeNull();
        propertyImage.PropertyId.Should().Be("507f1f77bcf86cd799439012");
        propertyImage.Image.Should().Be("house-front.jpg");
        propertyImage.Enabled.Should().Be(true);
    }

    [Test]
    public void PropertyImage_WithDisabledStatus_ShouldAcceptDisabledStatus()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = "house-back.jpg",
            Enabled = false
        };

        // Assert
        propertyImage.Enabled.Should().Be(false);
    }

    [Test]
    public void PropertyImage_WithEmptyId_ShouldAcceptEmptyId()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            Id = "",
            PropertyId = "507f1f77bcf86cd799439012",
            Image = "house-side.jpg",
            Enabled = true
        };

        // Assert
        propertyImage.Id.Should().Be("");
        propertyImage.Should().NotBeNull();
    }

    [Test]
    public void PropertyImage_WithImageUrl_ShouldAcceptImageUrl()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = "https://example.com/images/properties/house-garden.jpg",
            Enabled = true
        };

        // Assert
        propertyImage.Image.Should().Be("https://example.com/images/properties/house-garden.jpg");
    }

    [Test]
    public void PropertyImage_WithBase64Image_ShouldAcceptBase64Image()
    {
        // Arrange
        var base64Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD...";

        // Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = base64Image,
            Enabled = true
        };

        // Assert
        propertyImage.Image.Should().Be(base64Image);
    }

    [Test]
    public void PropertyImage_WithLongImagePath_ShouldAcceptLongImagePath()
    {
        // Arrange
        var longImagePath = "/very/long/path/to/images/properties/" + new string('a', 100) + ".jpg";

        // Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = longImagePath,
            Enabled = true
        };

        // Assert
        propertyImage.Image.Should().Be(longImagePath);
        propertyImage.Image.Length.Should().BeGreaterThan(100);
    }

    [Test]
    public void PropertyImage_WithSpecialCharactersInPath_ShouldAcceptSpecialCharacters()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439012",
            Image = "/images/properties/casa-con-ñ-y-acentos.jpg",
            Enabled = true
        };

        // Assert
        propertyImage.Image.Should().Be("/images/properties/casa-con-ñ-y-acentos.jpg");
    }

    [Test]
    public void PropertyImage_WithValidPropertyId_ShouldAcceptPropertyId()
    {
        // Arrange & Act
        var propertyImage = new PropertyImage
        {
            PropertyId = "507f1f77bcf86cd799439999",
            Image = "property-image.jpg",
            Enabled = true
        };

        // Assert
        propertyImage.PropertyId.Should().Be("507f1f77bcf86cd799439999");
    }
}
