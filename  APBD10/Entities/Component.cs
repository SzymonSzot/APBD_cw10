namespace APBD10.Entities;

public class Component
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
}