using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Entities;

[PrimaryKey(nameof(PcId), nameof(ComponentCode))]
public class PcComponent
{
    public int PcId { get; set; }
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }
    
    [ForeignKey(nameof(PcId))]
    public Pc Pc { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;
}