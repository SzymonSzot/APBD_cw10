using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Entities;

[Table("Components")]
public class Component
{
    [Key, Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    // nvarchaer(max) - default
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    
    [ForeignKey("ComponentTypeId")]
    public ComponentType ComponentType { get; set; } = null!;
    [ForeignKey("ComponentManufacturerId")]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public ICollection<PcComponent> PcComponents { get; set; } = [];
}