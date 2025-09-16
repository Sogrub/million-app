namespace Million.Application.DTOs;

public class CreateOwnerDto
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Photo { get; set; }
    public required string BirthDate { get; set; }
}