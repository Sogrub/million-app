namespace Million.Application.DTOs;

public class CreatePropertyDto
{
    public required string IdOwner { get; set; }
    public required string Name { get; set; }
    public required string AddressProperty { get; set; }
    public decimal PriceProperty { get; set; }
    public required string Type { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
}