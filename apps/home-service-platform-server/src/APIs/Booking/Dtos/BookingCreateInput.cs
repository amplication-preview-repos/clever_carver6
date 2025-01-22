namespace HomeServicePlatform.APIs.Dtos;

public class BookingCreateInput
{
    public DateTime? BookingDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? PaymentStatus { get; set; }

    public ServiceCategory? ServiceCategory { get; set; }

    public ServiceProvider? ServiceProvider { get; set; }

    public List<ServiceProvider>? ServiceProviders { get; set; }

    public string? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }

    public List<User>? Users { get; set; }
}
