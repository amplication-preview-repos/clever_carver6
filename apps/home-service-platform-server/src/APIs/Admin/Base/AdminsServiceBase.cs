using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using HomeServicePlatform.APIs.Extensions;
using HomeServicePlatform.Infrastructure;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.APIs;

public abstract class AdminsServiceBase : IAdminsService
{
    protected readonly HomeServicePlatformDbContext _context;

    public AdminsServiceBase(HomeServicePlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Admin
    /// </summary>
    public async Task<Admin> CreateAdmin(AdminCreateInput createDto)
    {
        var admin = new AdminDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            Name = createDto.Name,
            Permissions = createDto.Permissions,
            Role = createDto.Role,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            admin.Id = createDto.Id;
        }

        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AdminDbModel>(admin.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Admin
    /// </summary>
    public async Task DeleteAdmin(AdminWhereUniqueInput uniqueId)
    {
        var admin = await _context.Admins.FindAsync(uniqueId.Id);
        if (admin == null)
        {
            throw new NotFoundException();
        }

        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Admins
    /// </summary>
    public async Task<List<Admin>> Admins(AdminFindManyArgs findManyArgs)
    {
        var admins = await _context
            .Admins.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return admins.ConvertAll(admin => admin.ToDto());
    }

    /// <summary>
    /// Meta data about Admin records
    /// </summary>
    public async Task<MetadataDto> AdminsMeta(AdminFindManyArgs findManyArgs)
    {
        var count = await _context.Admins.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Admin
    /// </summary>
    public async Task<Admin> Admin(AdminWhereUniqueInput uniqueId)
    {
        var admins = await this.Admins(
            new AdminFindManyArgs { Where = new AdminWhereInput { Id = uniqueId.Id } }
        );
        var admin = admins.FirstOrDefault();
        if (admin == null)
        {
            throw new NotFoundException();
        }

        return admin;
    }

    /// <summary>
    /// Update one Admin
    /// </summary>
    public async Task UpdateAdmin(AdminWhereUniqueInput uniqueId, AdminUpdateInput updateDto)
    {
        var admin = updateDto.ToModel(uniqueId);

        _context.Entry(admin).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Admins.Any(e => e.Id == admin.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
