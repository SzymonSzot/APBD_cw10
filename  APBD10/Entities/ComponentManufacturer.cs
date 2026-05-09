using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Entities;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }

    public ICollection<Component> Components = [];
}