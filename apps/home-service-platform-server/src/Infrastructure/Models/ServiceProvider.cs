using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServicePlatform.Infrastructure.Models;

[Table("ServiceProviders")]
public class ServiceProviderDbModel
{
    [StringLength(1000)]
    public string? Availability { get; set; }

    [StringLength(1000)]
    public string? Bio { get; set; }

    public string? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    public List<BookingDbModel>? Bookings { get; set; } = new List<BookingDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [Range(-999999999, 999999999)]
    public double? HourlyRate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    [StringLength(1000)]
    public string? Ratings { get; set; }

    public string? ReviewId { get; set; }

    [ForeignKey(nameof(ReviewId))]
    public ReviewDbModel? Review { get; set; } = null;

    public List<ReviewDbModel>? Reviews { get; set; } = new List<ReviewDbModel>();

    public List<ServiceCategoryDbModel>? ServiceCategories { get; set; } =
        new List<ServiceCategoryDbModel>();

    [StringLength(1000)]
    public string? ServiceType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
