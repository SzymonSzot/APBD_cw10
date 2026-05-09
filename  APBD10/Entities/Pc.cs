using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Entities;

[Table("PC")]
public class Pc
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "float(5)")]
    public float Weight { get; set; }
    public int Warranty { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    
    public ICollection<PcComponent> PcComponents { get; set; } = [];
}