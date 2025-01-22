using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class ServiceCategoriesExtensions
{
    public static ServiceCategory ToDto(this ServiceCategoryDbModel model)
    {
        return new ServiceCategory
        {
            Bookings = model.Bookings?.Select(x => x.Id).ToList(),
            CategoryName = model.CategoryName,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            ServiceProvider = model.ServiceProviderId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceCategoryDbModel ToModel(
        this ServiceCategoryUpdateInput updateDto,
        ServiceCategoryWhereUniqueInput uniqueId
    )
    {
        var serviceCategory = new ServiceCategoryDbModel
        {
            Id = uniqueId.Id,
            CategoryName = updateDto.CategoryName,
            Description = updateDto.Description
        };

        if (updateDto.CreatedAt != null)
        {
            serviceCategory.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.ServiceProvider != null)
        {
            serviceCategory.ServiceProviderId = updateDto.ServiceProvider;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceCategory.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceCategory;
    }
}
