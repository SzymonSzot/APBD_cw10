using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Entities;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    
    public IList<Component> Components { get; set; } = [];
}