using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class ReviewsExtensions
{
    public static Review ToDto(this ReviewDbModel model)
    {
        return new Review
        {
            Comment = model.Comment,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Rating = model.Rating,
            ServiceProvider = model.ServiceProviderId,
            ServiceProviders = model.ServiceProviders?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            Users = model.Users?.Select(x => x.Id).ToList(),
        };
    }

    public static ReviewDbModel ToModel(
        this ReviewUpdateInput updateDto,
        ReviewWhereUniqueInput uniqueId
    )
    {
        var review = new ReviewDbModel
        {
            Id = uniqueId.Id,
            Comment = updateDto.Comment,
            Rating = updateDto.Rating
        };

        if (updateDto.CreatedAt != null)
        {
            review.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.ServiceProvider != null)
        {
            review.ServiceProviderId = updateDto.ServiceProvider;
        }
        if (updateDto.UpdatedAt != null)
        {
            review.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            review.UserId = updateDto.User;
        }

        return review;
    }
}
