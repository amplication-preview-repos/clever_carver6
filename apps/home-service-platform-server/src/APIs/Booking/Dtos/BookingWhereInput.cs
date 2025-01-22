namespace HomeServicePlatform.APIs.Dtos;

public class BookingWhereInput
{
    public DateTime? BookingDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? PaymentStatus { get; set; }

    public string? ServiceCategory { get; set; }

    public string? ServiceProvider { get; set; }

    public List<string>? ServiceProviders { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }

    public List<string>? Users { get; set; }
}
