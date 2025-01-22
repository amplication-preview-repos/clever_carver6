namespace HomeServicePlatform.APIs.Dtos;

public class ServiceCategoryCreateInput
{
    public List<Booking>? Bookings { get; set; }

    public string? CategoryName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public ServiceProvider? ServiceProvider { get; set; }

    public DateTime UpdatedAt { get; set; }
}
