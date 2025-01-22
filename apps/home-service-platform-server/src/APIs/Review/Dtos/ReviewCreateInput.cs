namespace HomeServicePlatform.APIs.Dtos;

public class ReviewCreateInput
{
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? Rating { get; set; }

    public ServiceProvider? ServiceProvider { get; set; }

    public List<ServiceProvider>? ServiceProviders { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }

    public List<User>? Users { get; set; }
}
