using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using HomeServicePlatform.APIs.Extensions;
using HomeServicePlatform.Infrastructure;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.APIs;

public abstract class ServiceCategoriesServiceBase : IServiceCategoriesService
{
    protected readonly HomeServicePlatformDbContext _context;

    public ServiceCategoriesServiceBase(HomeServicePlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceCategory
    /// </summary>
    public async Task<ServiceCategory> CreateServiceCategory(ServiceCategoryCreateInput createDto)
    {
        var serviceCategory = new ServiceCategoryDbModel
        {
            CategoryName = createDto.CategoryName,
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceCategory.Id = createDto.Id;
        }
        if (createDto.Bookings != null)
        {
            serviceCategory.Bookings = await _context
                .Bookings.Where(booking =>
                    createDto.Bookings.Select(t => t.Id).Contains(booking.Id)
                )
                .ToListAsync();
        }

        if (createDto.ServiceProvider != null)
        {
            serviceCategory.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    createDto.ServiceProvider.Id == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        _context.ServiceCategories.Add(serviceCategory);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceCategoryDbModel>(serviceCategory.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceCategory
    /// </summary>
    public async Task DeleteServiceCategory(ServiceCategoryWhereUniqueInput uniqueId)
    {
        var serviceCategory = await _context.ServiceCategories.FindAsync(uniqueId.Id);
        if (serviceCategory == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceCategories.Remove(serviceCategory);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceCategories
    /// </summary>
    public async Task<List<ServiceCategory>> ServiceCategories(
        ServiceCategoryFindManyArgs findManyArgs
    )
    {
        var serviceCategories = await _context
            .ServiceCategories.Include(x => x.ServiceProvider)
            .Include(x => x.Bookings)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceCategories.ConvertAll(serviceCategory => serviceCategory.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceCategory records
    /// </summary>
    public async Task<MetadataDto> ServiceCategoriesMeta(ServiceCategoryFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceCategories.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceCategory
    /// </summary>
    public async Task<ServiceCategory> ServiceCategory(ServiceCategoryWhereUniqueInput uniqueId)
    {
        var serviceCategories = await this.ServiceCategories(
            new ServiceCategoryFindManyArgs
            {
                Where = new ServiceCategoryWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceCategory = serviceCategories.FirstOrDefault();
        if (serviceCategory == null)
        {
            throw new NotFoundException();
        }

        return serviceCategory;
    }

    /// <summary>
    /// Update one ServiceCategory
    /// </summary>
    public async Task UpdateServiceCategory(
        ServiceCategoryWhereUniqueInput uniqueId,
        ServiceCategoryUpdateInput updateDto
    )
    {
        var serviceCategory = updateDto.ToModel(uniqueId);

        if (updateDto.Bookings != null)
        {
            serviceCategory.Bookings = await _context
                .Bookings.Where(booking => updateDto.Bookings.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.ServiceProvider != null)
        {
            serviceCategory.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    updateDto.ServiceProvider == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        _context.Entry(serviceCategory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceCategories.Any(e => e.Id == serviceCategory.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Bookings records to ServiceCategory
    /// </summary>
    public async Task ConnectBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceCategories.Include(x => x.Bookings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Bookings.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Bookings);

        foreach (var child in childrenToConnect)
        {
            parent.Bookings.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Bookings records from ServiceCategory
    /// </summary>
    public async Task DisconnectBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceCategories.Include(x => x.Bookings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Bookings.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Bookings?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Bookings records for ServiceCategory
    /// </summary>
    public async Task<List<Booking>> FindBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingFindManyArgs serviceCategoryFindManyArgs
    )
    {
        var bookings = await _context
            .Bookings.Where(m => m.ServiceCategoryId == uniqueId.Id)
            .ApplyWhere(serviceCategoryFindManyArgs.Where)
            .ApplySkip(serviceCategoryFindManyArgs.Skip)
            .ApplyTake(serviceCategoryFindManyArgs.Take)
            .ApplyOrderBy(serviceCategoryFindManyArgs.SortBy)
            .ToListAsync();

        return bookings.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Bookings records for ServiceCategory
    /// </summary>
    public async Task UpdateBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var serviceCategory = await _context
            .ServiceCategories.Include(t => t.Bookings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (serviceCategory == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Bookings.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        serviceCategory.Bookings = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a ServiceProvider record for ServiceCategory
    /// </summary>
    public async Task<ServiceProvider> GetServiceProvider(ServiceCategoryWhereUniqueInput uniqueId)
    {
        var serviceCategory = await _context
            .ServiceCategories.Where(serviceCategory => serviceCategory.Id == uniqueId.Id)
            .Include(serviceCategory => serviceCategory.ServiceProvider)
            .FirstOrDefaultAsync();
        if (serviceCategory == null)
        {
            throw new NotFoundException();
        }
        return serviceCategory.ServiceProvider.ToDto();
    }
}
