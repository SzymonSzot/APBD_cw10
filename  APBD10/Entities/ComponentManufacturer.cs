namespace APBD10.Entities;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateOnly FoundationDate { get; set; }

    public ICollection<Component> Components = [];
}