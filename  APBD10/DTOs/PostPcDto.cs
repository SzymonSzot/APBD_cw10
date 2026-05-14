using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.DTOs;

public class PostPcDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public float Weight { get; set; }
    [Required]
    public int Warranty { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public int Stock { get; set; }
}