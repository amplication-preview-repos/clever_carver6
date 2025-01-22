using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServicePlatform.Infrastructure.Models;

[Table("Admins")]
public class AdminDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? Permissions { get; set; }

    [StringLength(1000)]
    public string? Role { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
