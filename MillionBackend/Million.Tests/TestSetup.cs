using Microsoft.Extensions.Configuration;
using Million.Infrastructure.Database;

namespace Million.Tests;

public static class TestSetup
{
    public static IConfiguration CreateTestConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Test.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        return configuration;
    }

    public static MongoDbContext CreateTestMongoDbContext()
    {
        var configuration = CreateTestConfiguration();
        return new MongoDbContext(configuration);
    }

    public static List<Million.Domain.Entities.Property> GetSampleProperties()
    {
        return new List<Million.Domain.Entities.Property>
        {
            new Million.Domain.Entities.Property
            {
                Id = "507f1f77bcf86cd799439011",
                IdOwner = "507f1f77bcf86cd799439012",
                Name = "Casa en el centro",
                AddressProperty = "Calle Principal 123",
                PriceProperty = 250000m
            },
            new Million.Domain.Entities.Property
            {
                Id = "507f1f77bcf86cd799439013",
                IdOwner = "507f1f77bcf86cd799439014",
                Name = "Apartamento moderno",
                AddressProperty = "Avenida Secundaria 456",
                PriceProperty = 180000m
            },
            new Million.Domain.Entities.Property
            {
                Id = "507f1f77bcf86cd799439015",
                IdOwner = "507f1f77bcf86cd799439016",
                Name = "Villa de lujo",
                AddressProperty = "Residencial Premium 789",
                PriceProperty = 500000m
            }
        };
    }

    public static List<Million.Application.DTOs.CreatePropertyDto> GetSampleCreatePropertyDtos()
    {
        return new List<Million.Application.DTOs.CreatePropertyDto>
        {
            new Million.Application.DTOs.CreatePropertyDto
            {
                IdOwner = "507f1f77bcf86cd799439012",
                Name = "Casa en el centro",
                AddressProperty = "Calle Principal 123",
                PriceProperty = 250000m,
                Image = "casa-centro.jpg"
            },
            new Million.Application.DTOs.CreatePropertyDto
            {
                IdOwner = "507f1f77bcf86cd799439014",
                Name = "Apartamento moderno",
                AddressProperty = "Avenida Secundaria 456",
                PriceProperty = 180000m,
                Image = "apartamento-moderno.jpg"
            },
            new Million.Application.DTOs.CreatePropertyDto
            {
                IdOwner = "507f1f77bcf86cd799439016",
                Name = "Villa de lujo",
                AddressProperty = "Residencial Premium 789",
                PriceProperty = 500000m,
                Image = "villa-lujo.jpg"
            }
        };
    }

    public static List<Million.Domain.Entities.Owner> GetSampleOwners()
    {
        return new List<Million.Domain.Entities.Owner>
        {
            new Million.Domain.Entities.Owner
            {
                Id = "507f1f77bcf86cd799439012",
                Name = "Juan Pérez",
                Address = "Calle Principal 123",
                Photo = "juan-perez.jpg",
                BirthDate = "1990-01-15"
            },
            new Million.Domain.Entities.Owner
            {
                Id = "507f1f77bcf86cd799439014",
                Name = "María García",
                Address = "Avenida Central 456",
                Photo = "maria-garcia.jpg",
                BirthDate = "1985-05-20"
            },
            new Million.Domain.Entities.Owner
            {
                Id = "507f1f77bcf86cd799439016",
                Name = "Carlos Ruiz",
                Address = "Plaza Mayor 321",
                Photo = "carlos-ruiz.jpg",
                BirthDate = "1995-07-08"
            }
        };
    }

    public static List<Million.Domain.Entities.PropertyImage> GetSamplePropertyImages()
    {
        return new List<Million.Domain.Entities.PropertyImage>
        {
            new Million.Domain.Entities.PropertyImage
            {
                Id = "507f1f77bcf86cd799439021",
                PropertyId = "507f1f77bcf86cd799439011",
                Image = "casa-centro-frontal.jpg",
                Enabled = true
            },
            new Million.Domain.Entities.PropertyImage
            {
                Id = "507f1f77bcf86cd799439022",
                PropertyId = "507f1f77bcf86cd799439013",
                Image = "apartamento-moderno-interior.jpg",
                Enabled = true
            },
            new Million.Domain.Entities.PropertyImage
            {
                Id = "507f1f77bcf86cd799439023",
                PropertyId = "507f1f77bcf86cd799439015",
                Image = "villa-lujo-jardin.jpg",
                Enabled = true
            }
        };
    }

    public static List<Million.Domain.Entities.PropertyTrace> GetSamplePropertyTraces()
    {
        return new List<Million.Domain.Entities.PropertyTrace>
        {
            new Million.Domain.Entities.PropertyTrace
            {
                Id = "507f1f77bcf86cd799439031",
                PropertyId = "507f1f77bcf86cd799439011",
                DateSale = "2023-12-15",
                Name = "Venta de propiedad",
                Value = 250000,
                Tax = 25000
            },
            new Million.Domain.Entities.PropertyTrace
            {
                Id = "507f1f77bcf86cd799439032",
                PropertyId = "507f1f77bcf86cd799439013",
                DateSale = "2023-11-20",
                Name = "Compra inicial",
                Value = 180000,
                Tax = 18000
            },
            new Million.Domain.Entities.PropertyTrace
            {
                Id = "507f1f77bcf86cd799439033",
                PropertyId = "507f1f77bcf86cd799439015",
                DateSale = "2023-10-05",
                Name = "Venta de mansión",
                Value = 500000,
                Tax = 50000
            }
        };
    }
}