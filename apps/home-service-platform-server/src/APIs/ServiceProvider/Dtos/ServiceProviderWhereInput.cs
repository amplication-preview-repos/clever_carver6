namespace HomeServicePlatform.APIs.Dtos;

public class ServiceProviderWhereInput
{
    public string? Availability { get; set; }

    public string? Bio { get; set; }

    public string? Booking { get; set; }

    public List<string>? Bookings { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public double? HourlyRate { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Ratings { get; set; }

    public string? Review { get; set; }

    public List<string>? Reviews { get; set; }

    public List<string>? ServiceCategories { get; set; }

    public string? ServiceType { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
