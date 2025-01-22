using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.Infrastructure.Models;

namespace HomeServicePlatform.APIs.Extensions;

public static class AdminsExtensions
{
    public static Admin ToDto(this AdminDbModel model)
    {
        return new Admin
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            Permissions = model.Permissions,
            Role = model.Role,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AdminDbModel ToModel(
        this AdminUpdateInput updateDto,
        AdminWhereUniqueInput uniqueId
    )
    {
        var admin = new AdminDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            Name = updateDto.Name,
            Permissions = updateDto.Permissions,
            Role = updateDto.Role
        };

        if (updateDto.CreatedAt != null)
        {
            admin.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            admin.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return admin;
    }
}
