namespace HomeServicePlatform.APIs.Dtos;

public class ServiceProviderCreateInput
{
    public string? Availability { get; set; }

    public string? Bio { get; set; }

    public Booking? Booking { get; set; }

    public List<Booking>? Bookings { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public double? HourlyRate { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Ratings { get; set; }

    public Review? Review { get; set; }

    public List<Review>? Reviews { get; set; }

    public List<ServiceCategory>? ServiceCategories { get; set; }

    public string? ServiceType { get; set; }

    public DateTime UpdatedAt { get; set; }
}
