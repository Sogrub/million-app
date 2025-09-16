using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Million.Domain.Entities;
using Million.Infrastructure.Database;
using Million.Application.DTOs;
using MongoDB.Bson;

namespace Million.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PropertiesController : ControllerBase
{
    private readonly IMongoDbContext _context;

    public PropertiesController(IMongoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all properties with optional filters (search, type, price range).
    /// </summary>
    /// <param name="search">Search term for name or address</param>
    /// <param name="type">Property type</param>
    /// <param name="minPrice">Minimum price</param>
    /// <param name="maxPrice">Maximum price</param>
    /// <returns>List of properties</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Property>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetProperties(
        string? search, string? type, decimal? minPrice, decimal? maxPrice)
    {
        var filter = Builders<Property>.Filter.Empty;

        if (!string.IsNullOrEmpty(search))
        {
            var regex = new MongoDB.Bson.BsonRegularExpression(search, "i");
            filter &= Builders<Property>.Filter.Or(
                Builders<Property>.Filter.Regex(p => p.Name, regex),
                Builders<Property>.Filter.Regex(p => p.AddressProperty, regex)
            );
        }

        if (!string.IsNullOrEmpty(type))
            filter &= Builders<Property>.Filter.Eq(p => p.Type, type);

         if (minPrice.HasValue)
            filter &= Builders<Property>.Filter.Gte(p => p.PriceProperty, minPrice.Value);
        if (maxPrice.HasValue)
            filter &= Builders<Property>.Filter.Lte(p => p.PriceProperty, maxPrice.Value);

        var properties = await _context.Properties.Find(filter).ToListAsync();

        var result = new List<object>();
        foreach (var prop in properties)
        {
            var owner = await _context.Owners.Find(o => o.Id == prop.IdOwner).FirstOrDefaultAsync();
            var images = await _context.PropertyImages
                .Find(i => i.PropertyId == prop.Id && i.Enabled)
                .Project(i => i.Image)
                .ToListAsync();

            result.Add(new
            {
                prop.Id,
                prop.Name,
                prop.AddressProperty,
                prop.PriceProperty,
                prop.Type,
                Owner = owner?.Name,
                Images = images,
            });
        }

        return Ok(result);
    }

    /// <summary>
    /// Retrieves a property by its ID.
    /// </summary>
    /// <param name="id">Property ID</param>
    /// <returns>A property</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Property), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProperty(string id)
    {
        var prop = await _context.Properties.Find(p => p.Id == id).FirstOrDefaultAsync();
        if (prop == null) return NotFound();

        var owner = await _context.Owners.Find(o => o.Id == prop.IdOwner).FirstOrDefaultAsync();
        var images = await _context.PropertyImages.Find(i => i.PropertyId == prop.Id && i.Enabled).ToListAsync();

        return Ok(new
        {
            prop.Id,
            prop.Name,
            prop.AddressProperty,
            prop.PriceProperty,
            prop.Description,
            Owner = owner,
            Images = images,
        });
    }

    /// <summary>
    /// Creates a new property.
    /// </summary>
    /// <param name="dto">Property data</param>
    /// <returns>The created property</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Property), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyDto dto)
    {
        if (dto == null) return BadRequest();

        if (!ObjectId.TryParse(dto.IdOwner, out var ownerObjectId))
            return BadRequest($"El IdOwner '{dto.IdOwner}' no es un ObjectId válido.");

        var owner = await _context.Owners.Find(o => o.Id == dto.IdOwner).FirstOrDefaultAsync();
        if (owner == null) return NotFound($"Owner with ID {dto.IdOwner} not found");

        var property = new Property
        {
            IdOwner = dto.IdOwner,
            Name = dto.Name,
            AddressProperty = dto.AddressProperty,
            PriceProperty = dto.PriceProperty,
            Type = dto.Type,
        };

        await _context.Properties.InsertOneAsync(property);

        var image = new PropertyImage
        {
            PropertyId = property.Id!,
            Image = dto.Image,
            Enabled = true
        };

        await _context.PropertyImages.InsertOneAsync(image);

        return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
    }
}