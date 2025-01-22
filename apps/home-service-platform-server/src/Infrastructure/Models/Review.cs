using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServicePlatform.Infrastructure.Models;

[Table("Reviews")]
public class ReviewDbModel
{
    [StringLength(1000)]
    public string? Comment { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Rating { get; set; }

    public string? ServiceProviderId { get; set; }

    [ForeignKey(nameof(ServiceProviderId))]
    public ServiceProviderDbModel? ServiceProvider { get; set; } = null;

    public List<ServiceProviderDbModel>? ServiceProviders { get; set; } =
        new List<ServiceProviderDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public List<UserDbModel>? Users { get; set; } = new List<UserDbModel>();
}
