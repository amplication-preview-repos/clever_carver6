using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class BookingsExtensions
{
    public static Booking ToDto(this BookingDbModel model)
    {
        return new Booking
        {
            BookingDate = model.BookingDate,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PaymentStatus = model.PaymentStatus,
            ServiceCategory = model.ServiceCategoryId,
            ServiceProvider = model.ServiceProviderId,
            ServiceProviders = model.ServiceProviders?.Select(x => x.Id).ToList(),
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            Users = model.Users?.Select(x => x.Id).ToList(),
        };
    }

    public static BookingDbModel ToModel(
        this BookingUpdateInput updateDto,
        BookingWhereUniqueInput uniqueId
    )
    {
        var booking = new BookingDbModel
        {
            Id = uniqueId.Id,
            BookingDate = updateDto.BookingDate,
            PaymentStatus = updateDto.PaymentStatus,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            booking.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.ServiceCategory != null)
        {
            booking.ServiceCategoryId = updateDto.ServiceCategory;
        }
        if (updateDto.ServiceProvider != null)
        {
            booking.ServiceProviderId = updateDto.ServiceProvider;
        }
        if (updateDto.UpdatedAt != null)
        {
            booking.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            booking.UserId = updateDto.User;
        }

        return booking;
    }
}
