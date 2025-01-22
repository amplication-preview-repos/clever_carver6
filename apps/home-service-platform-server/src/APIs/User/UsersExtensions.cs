using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            Address = model.Address,
            Booking = model.BookingId,
            Bookings = model.Bookings?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Name = model.Name,
            Password = model.Password,
            PaymentMethods = model.PaymentMethods,
            Phone = model.Phone,
            Review = model.ReviewId,
            Reviews = model.Reviews?.Select(x => x.Id).ToList(),
            Roles = model.Roles,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Name = updateDto.Name,
            PaymentMethods = updateDto.PaymentMethods,
            Phone = updateDto.Phone
        };

        if (updateDto.Booking != null)
        {
            user.BookingId = updateDto.Booking;
        }
        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Review != null)
        {
            user.ReviewId = updateDto.Review;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
