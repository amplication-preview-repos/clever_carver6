namespace HomeServicePlatform.APIs.Dtos;

public class AdminWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Permissions { get; set; }

    public string? Role { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
