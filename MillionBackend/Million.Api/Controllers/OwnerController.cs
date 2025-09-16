using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Million.Domain.Entities;
using Million.Infrastructure.Database;
using Million.Application.DTOs;

namespace Million.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class OwnerController : ControllerBase
{
    private readonly IMongoDbContext _context;

    public OwnerController(IMongoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all owners with optional filters.
    /// </summary>
    /// <param name="name">Owner name</param>
    /// <param name="address">Owner address</param>
    /// <param name="minBirthDate">Minimum birth date</param>
    /// <param name="maxBirthDate">Maximum birth date</param>
    /// <returns>List of owners</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Owner>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetOwners(
        string? name, string? address, string? minBirthDate, string? maxBirthDate)
    {
        var filter = Builders<Owner>.Filter.Empty;

        if (!string.IsNullOrEmpty(name))
            filter &= Builders<Owner>.Filter.Regex(o => o.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));
        if (!string.IsNullOrEmpty(address))
            filter &= Builders<Owner>.Filter.Regex(o => o.Address, new MongoDB.Bson.BsonRegularExpression(address, "i"));
        if (!string.IsNullOrEmpty(minBirthDate))
            filter &= Builders<Owner>.Filter.Gte(o => o.BirthDate, minBirthDate);
        if (!string.IsNullOrEmpty(maxBirthDate))
            filter &= Builders<Owner>.Filter.Lte(o => o.BirthDate, maxBirthDate);

        var owners = await _context.Owners.Find(filter).ToListAsync();
        return Ok(owners);
    }

    /// <summary>
    /// Retrieves an owner by its ID.
    /// </summary>
    /// <param name="id">Owner ID</param>
    /// <returns>An owner</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Owner), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetOwner(string id)
    {
        var owner = await _context.Owners.Find(o => o.Id == id).FirstOrDefaultAsync();
        if (owner == null) return NotFound();
        return Ok(owner);
    }

    /// <summary>
    /// Creates a new owner.
    /// </summary>
    /// <param name="dto">Owner data</param>
    /// <returns>The created owner</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Owner), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateOwner([FromBody] CreateOwnerDto dto)
    {
        if (dto == null) return BadRequest();

        var owner = new Owner
        {
            Name = dto.Name,
            Address = dto.Address,
            Photo = dto.Photo,
            BirthDate = dto.BirthDate
        };

        await _context.Owners.InsertOneAsync(owner);
        return CreatedAtAction(nameof(GetOwner), new { id = owner.Id }, owner);
    }
}