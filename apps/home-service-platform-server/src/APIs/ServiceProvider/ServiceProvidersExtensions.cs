using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class ServiceProvidersExtensions
{
    public static ServiceProvider ToDto(this ServiceProviderDbModel model)
    {
        return new ServiceProvider
        {
            Availability = model.Availability,
            Bio = model.Bio,
            Booking = model.BookingId,
            Bookings = model.Bookings?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            HourlyRate = model.HourlyRate,
            Id = model.Id,
            Name = model.Name,
            Phone = model.Phone,
            Ratings = model.Ratings,
            Review = model.ReviewId,
            Reviews = model.Reviews?.Select(x => x.Id).ToList(),
            ServiceCategories = model.ServiceCategories?.Select(x => x.Id).ToList(),
            ServiceType = model.ServiceType,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceProviderDbModel ToModel(
        this ServiceProviderUpdateInput updateDto,
        ServiceProviderWhereUniqueInput uniqueId
    )
    {
        var serviceProvider = new ServiceProviderDbModel
        {
            Id = uniqueId.Id,
            Availability = updateDto.Availability,
            Bio = updateDto.Bio,
            Email = updateDto.Email,
            HourlyRate = updateDto.HourlyRate,
            Name = updateDto.Name,
            Phone = updateDto.Phone,
            Ratings = updateDto.Ratings,
            ServiceType = updateDto.ServiceType
        };

        if (updateDto.Booking != null)
        {
            serviceProvider.BookingId = updateDto.Booking;
        }
        if (updateDto.CreatedAt != null)
        {
            serviceProvider.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Review != null)
        {
            serviceProvider.ReviewId = updateDto.Review;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceProvider.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceProvider;
    }
}
