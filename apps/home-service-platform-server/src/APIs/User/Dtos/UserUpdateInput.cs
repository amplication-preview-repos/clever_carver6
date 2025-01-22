namespace HomeServicePlatform.APIs.Dtos;

public class UserUpdateInput
{
    public string? Address { get; set; }

    public string? Booking { get; set; }

    public List<string>? Bookings { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? PaymentMethods { get; set; }

    public string? Phone { get; set; }

    public string? Review { get; set; }

    public List<string>? Reviews { get; set; }

    public string? Roles { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }
}
