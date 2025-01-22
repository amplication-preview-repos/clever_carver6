namespace HomeServicePlatform.APIs.Dtos;

public class ServiceCategory
{
    public List<string>? Bookings { get; set; }

    public string? CategoryName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string Id { get; set; }

    public string? ServiceProvider { get; set; }

    public DateTime UpdatedAt { get; set; }
}
