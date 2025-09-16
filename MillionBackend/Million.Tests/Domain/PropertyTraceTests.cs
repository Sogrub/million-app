using FluentAssertions;
using Million.Domain.Entities;

namespace Million.Tests.Domain;

[TestFixture]
public class PropertyTraceTests
{
    [Test]
    public void PropertyTrace_Constructor_WithValidData_ShouldCreatePropertyTrace()
    {
        // Arrange
        var id = "507f1f77bcf86cd799439011";
        var propertyId = "507f1f77bcf86cd799439012";
        var dateSale = "2023-12-15";
        var name = "Venta de propiedad";
        var value = 250000;
        var tax = 25000;

        // Act
        var propertyTrace = new PropertyTrace
        {
            Id = id,
            PropertyId = propertyId,
            DateSale = dateSale,
            Name = name,
            Value = value,
            Tax = tax
        };

        // Assert
        propertyTrace.Should().NotBeNull();
        propertyTrace.Id.Should().Be(id);
        propertyTrace.PropertyId.Should().Be(propertyId);
        propertyTrace.DateSale.Should().Be(dateSale);
        propertyTrace.Name.Should().Be(name);
        propertyTrace.Value.Should().Be(value);
        propertyTrace.Tax.Should().Be(tax);
    }

    [Test]
    public void PropertyTrace_WithRequiredFields_ShouldCreatePropertyTrace()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-11-20",
            Name = "Compra inicial",
            Value = 200000,
            Tax = 20000
        };

        // Assert
        propertyTrace.Should().NotBeNull();
        propertyTrace.PropertyId.Should().Be("507f1f77bcf86cd799439012");
        propertyTrace.DateSale.Should().Be("2023-11-20");
        propertyTrace.Name.Should().Be("Compra inicial");
        propertyTrace.Value.Should().Be(200000);
        propertyTrace.Tax.Should().Be(20000);
    }

    [Test]
    public void PropertyTrace_WithZeroValue_ShouldAcceptZeroValue()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-10-15",
            Name = "Transferencia sin costo",
            Value = 0,
            Tax = 0
        };

        // Assert
        propertyTrace.Value.Should().Be(0);
        propertyTrace.Tax.Should().Be(0);
    }

    [Test]
    public void PropertyTrace_WithNegativeValue_ShouldAcceptNegativeValue()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-09-10",
            Name = "Reembolso",
            Value = -5000,
            Tax = -500
        };

        // Assert
        propertyTrace.Value.Should().Be(-5000);
        propertyTrace.Tax.Should().Be(-500);
    }

    [Test]
    public void PropertyTrace_WithHighValue_ShouldAcceptHighValue()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-08-05",
            Name = "Venta de mansión",
            Value = 999999999,
            Tax = 99999999
        };

        // Assert
        propertyTrace.Value.Should().Be(999999999);
        propertyTrace.Tax.Should().Be(99999999);
    }

    [Test]
    public void PropertyTrace_WithSpecialCharactersInName_ShouldAcceptSpecialCharacters()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-07-01",
            Name = "Venta con ñ y acentos áéíóú",
            Value = 300000,
            Tax = 30000
        };

        // Assert
        propertyTrace.Name.Should().Be("Venta con ñ y acentos áéíóú");
    }

    [Test]
    public void PropertyTrace_WithLongName_ShouldAcceptLongName()
    {
        // Arrange
        var longName = "Transacción muy larga con muchos detalles " + new string('a', 100);

        // Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-06-15",
            Name = longName,
            Value = 150000,
            Tax = 15000
        };

        // Assert
        propertyTrace.Name.Should().Be(longName);
        propertyTrace.Name.Length.Should().BeGreaterThan(100);
    }

    [Test]
    public void PropertyTrace_WithValidDateSale_ShouldAcceptDateSale()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439012",
            DateSale = "2023-12-31",
            Name = "Venta de fin de año",
            Value = 400000,
            Tax = 40000
        };

        // Assert
        propertyTrace.DateSale.Should().Be("2023-12-31");
    }

    [Test]
    public void PropertyTrace_WithValidPropertyId_ShouldAcceptPropertyId()
    {
        // Arrange & Act
        var propertyTrace = new PropertyTrace
        {
            Id = "507f1f77bcf86cd799439011",
            PropertyId = "507f1f77bcf86cd799439999",
            DateSale = "2023-05-20",
            Name = "Venta de propiedad",
            Value = 350000,
            Tax = 35000
        };

        // Assert
        propertyTrace.PropertyId.Should().Be("507f1f77bcf86cd799439999");
    }
}
