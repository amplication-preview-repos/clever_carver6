using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeServicePlatform.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    public string? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    public List<BookingDbModel>? Bookings { get; set; } = new List<BookingDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Required()]
    public string Password { get; set; }

    [StringLength(1000)]
    public string? PaymentMethods { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    public string? ReviewId { get; set; }

    [ForeignKey(nameof(ReviewId))]
    public ReviewDbModel? Review { get; set; } = null;

    public List<ReviewDbModel>? Reviews { get; set; } = new List<ReviewDbModel>();

    [Required()]
    public string Roles { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }
}
