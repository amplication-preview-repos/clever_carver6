using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServicePlatform.Infrastructure.Models;

[Table("Bookings")]
public class BookingDbModel
{
    public DateTime? BookingDate { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? PaymentStatus { get; set; }

    public string? ServiceCategoryId { get; set; }

    [ForeignKey(nameof(ServiceCategoryId))]
    public ServiceCategoryDbModel? ServiceCategory { get; set; } = null;

    public string? ServiceProviderId { get; set; }

    [ForeignKey(nameof(ServiceProviderId))]
    public ServiceProviderDbModel? ServiceProvider { get; set; } = null;

    public List<ServiceProviderDbModel>? ServiceProviders { get; set; } =
        new List<ServiceProviderDbModel>();

    [StringLength(1000)]
    public string? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public List<UserDbModel>? Users { get; set; } = new List<UserDbModel>();
}
