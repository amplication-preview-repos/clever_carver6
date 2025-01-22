namespace HomeServicePlatform.APIs.Dtos;

public class ReviewWhereInput
{
    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public int? Rating { get; set; }

    public string? ServiceProvider { get; set; }

    public List<string>? ServiceProviders { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }

    public List<string>? Users { get; set; }
}
