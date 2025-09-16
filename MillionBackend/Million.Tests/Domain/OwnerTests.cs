using FluentAssertions;
using Million.Domain.Entities;

namespace Million.Tests.Domain;

[TestFixture]
public class OwnerTests
{
    [Test]
    public void Owner_Constructor_WithValidData_ShouldCreateOwner()
    {
        // Arrange
        var id = "507f1f77bcf86cd799439011";
        var name = "Juan Pérez";
        var address = "Calle Principal 123";
        var photo = "juan-perez.jpg";
        var birthDate = "1990-01-15";

        // Act
        var owner = new Owner
        {
            Id = id,
            Name = name,
            Address = address,
            Photo = photo,
            BirthDate = birthDate
        };

        // Assert
        owner.Should().NotBeNull();
        owner.Id.Should().Be(id);
        owner.Name.Should().Be(name);
        owner.Address.Should().Be(address);
        owner.Photo.Should().Be(photo);
        owner.BirthDate.Should().Be(birthDate);
    }

    [Test]
    public void Owner_WithRequiredFields_ShouldCreateOwner()
    {
        // Arrange & Act
        var owner = new Owner
        {
            Name = "María García",
            Address = "Avenida Central 456",
            Photo = "maria-garcia.jpg",
            BirthDate = "1985-05-20"
        };

        // Assert
        owner.Should().NotBeNull();
        owner.Name.Should().Be("María García");
        owner.Address.Should().Be("Avenida Central 456");
        owner.Photo.Should().Be("maria-garcia.jpg");
        owner.BirthDate.Should().Be("1985-05-20");
    }

    [Test]
    public void Owner_WithSpecialCharactersInName_ShouldAcceptSpecialCharacters()
    {
        // Arrange & Act
        var owner = new Owner
        {
            Name = "José María ñ y acentos áéíóú",
            Address = "Calle Especial 789",
            Photo = "jose-maria.jpg",
            BirthDate = "1992-12-25"
        };

        // Assert
        owner.Name.Should().Be("José María ñ y acentos áéíóú");
    }

    [Test]
    public void Owner_WithLongAddress_ShouldAcceptLongAddress()
    {
        // Arrange
        var longAddress = new string('A', 500);

        // Act
        var owner = new Owner
        {
            Name = "Ana López",
            Address = longAddress,
            Photo = "ana-lopez.jpg",
            BirthDate = "1988-03-10"
        };

        // Assert
        owner.Address.Should().Be(longAddress);
        owner.Address.Length.Should().Be(500);
    }

    [Test]
    public void Owner_WithEmptyId_ShouldAcceptEmptyId()
    {
        // Arrange & Act
        var owner = new Owner
        {
            Id = "",
            Name = "Carlos Ruiz",
            Address = "Plaza Mayor 321",
            Photo = "carlos-ruiz.jpg",
            BirthDate = "1995-07-08"
        };

        // Assert
        owner.Id.Should().Be("");
        owner.Should().NotBeNull();
    }

    [Test]
    public void Owner_WithValidBirthDate_ShouldAcceptBirthDate()
    {
        // Arrange & Act
        var owner = new Owner
        {
            Name = "Laura Martínez",
            Address = "Calle Nueva 654",
            Photo = "laura-martinez.jpg",
            BirthDate = "2000-11-30"
        };

        // Assert
        owner.BirthDate.Should().Be("2000-11-30");
    }

    [Test]
    public void Owner_WithPhotoPath_ShouldAcceptPhotoPath()
    {
        // Arrange & Act
        var owner = new Owner
        {
            Name = "Pedro Sánchez",
            Address = "Avenida Grande 987",
            Photo = "/images/owners/pedro-sanchez-profile.jpg",
            BirthDate = "1987-09-12"
        };

        // Assert
        owner.Photo.Should().Be("/images/owners/pedro-sanchez-profile.jpg");
    }
}
