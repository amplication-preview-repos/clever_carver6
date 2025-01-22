using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using HomeServicePlatform.APIs.Extensions;
using HomeServicePlatform.Infrastructure;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.APIs;

public abstract class ServiceProvidersServiceBase : IServiceProvidersService
{
    protected readonly HomeServicePlatformDbContext _context;

    public ServiceProvidersServiceBase(HomeServicePlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceProvider
    /// </summary>
    public async Task<ServiceProvider> CreateServiceProvider(ServiceProviderCreateInput createDto)
    {
        var serviceProvider = new ServiceProviderDbModel
        {
            Availability = createDto.Availability,
            Bio = createDto.Bio,
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            HourlyRate = createDto.HourlyRate,
            Name = createDto.Name,
            Phone = createDto.Phone,
            Ratings = createDto.Ratings,
            ServiceType = createDto.ServiceType,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceProvider.Id = createDto.Id;
        }
        if (createDto.Booking != null)
        {
            serviceProvider.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Bookings != null)
        {
            serviceProvider.Bookings = await _context
                .Bookings.Where(booking =>
                    createDto.Bookings.Select(t => t.Id).Contains(booking.Id)
                )
                .ToListAsync();
        }

        if (createDto.Review != null)
        {
            serviceProvider.Review = await _context
                .Reviews.Where(review => createDto.Review.Id == review.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Reviews != null)
        {
            serviceProvider.Reviews = await _context
                .Reviews.Where(review => createDto.Reviews.Select(t => t.Id).Contains(review.Id))
                .ToListAsync();
        }

        if (createDto.ServiceCategories != null)
        {
            serviceProvider.ServiceCategories = await _context
                .ServiceCategories.Where(serviceCategory =>
                    createDto.ServiceCategories.Select(t => t.Id).Contains(serviceCategory.Id)
                )
                .ToListAsync();
        }

        _context.ServiceProviders.Add(serviceProvider);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceProviderDbModel>(serviceProvider.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceProvider
    /// </summary>
    public async Task DeleteServiceProvider(ServiceProviderWhereUniqueInput uniqueId)
    {
        var serviceProvider = await _context.ServiceProviders.FindAsync(uniqueId.Id);
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceProviders.Remove(serviceProvider);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceProviders
    /// </summary>
    public async Task<List<ServiceProvider>> ServiceProviders(
        ServiceProviderFindManyArgs findManyArgs
    )
    {
        var serviceProviders = await _context
            .ServiceProviders.Include(x => x.ServiceCategories)
            .Include(x => x.Booking)
            .Include(x => x.Review)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceProviders.ConvertAll(serviceProvider => serviceProvider.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceProvider records
    /// </summary>
    public async Task<MetadataDto> ServiceProvidersMeta(ServiceProviderFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceProviders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceProvider
    /// </summary>
    public async Task<ServiceProvider> ServiceProvider(ServiceProviderWhereUniqueInput uniqueId)
    {
        var serviceProviders = await this.ServiceProviders(
            new ServiceProviderFindManyArgs
            {
                Where = new ServiceProviderWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceProvider = serviceProviders.FirstOrDefault();
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }

        return serviceProvider;
    }

    /// <summary>
    /// Update one ServiceProvider
    /// </summary>
    public async Task UpdateServiceProvider(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceProviderUpdateInput updateDto
    )
    {
        var serviceProvider = updateDto.ToModel(uniqueId);

        if (updateDto.Booking != null)
        {
            serviceProvider.Booking = await _context
                .Bookings.Where(booking => updateDto.Booking == booking.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Bookings != null)
        {
            serviceProvider.Bookings = await _context
                .Bookings.Where(booking => updateDto.Bookings.Select(t => t).Contains(booking.Id))
                .ToListAsync();
        }

        if (updateDto.Review != null)
        {
            serviceProvider.Review = await _context
                .Reviews.Where(review => updateDto.Review == review.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Reviews != null)
        {
            serviceProvider.Reviews = await _context
                .Reviews.Where(review => updateDto.Reviews.Select(t => t).Contains(review.Id))
                .ToListAsync();
        }

        if (updateDto.ServiceCategories != null)
        {
            serviceProvider.ServiceCategories = await _context
                .ServiceCategories.Where(serviceCategory =>
                    updateDto.ServiceCategories.Select(t => t).Contains(serviceCategory.Id)
                )
                .ToListAsync();
        }

        _context.Entry(serviceProvider).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceProviders.Any(e => e.Id == serviceProvider.Id))
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
    /// Get a Booking record for ServiceProvider
    /// </summary>
    public async Task<Booking> GetBooking(ServiceProviderWhereUniqueInput uniqueId)
    {
        var serviceProvider = await _context
            .ServiceProviders.Where(serviceProvider => serviceProvider.Id == uniqueId.Id)
            .Include(serviceProvider => serviceProvider.Booking)
            .FirstOrDefaultAsync();
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }
        return serviceProvider.Booking.ToDto();
    }

    /// <summary>
    /// Connect multiple Bookings records to ServiceProvider
    /// </summary>
    public async Task ConnectBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.Bookings)
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
    /// Disconnect multiple Bookings records from ServiceProvider
    /// </summary>
    public async Task DisconnectBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.Bookings)
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
    /// Find multiple Bookings records for ServiceProvider
    /// </summary>
    public async Task<List<Booking>> FindBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingFindManyArgs serviceProviderFindManyArgs
    )
    {
        var bookings = await _context
            .Bookings.Where(m => m.ServiceProviderId == uniqueId.Id)
            .ApplyWhere(serviceProviderFindManyArgs.Where)
            .ApplySkip(serviceProviderFindManyArgs.Skip)
            .ApplyTake(serviceProviderFindManyArgs.Take)
            .ApplyOrderBy(serviceProviderFindManyArgs.SortBy)
            .ToListAsync();

        return bookings.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Bookings records for ServiceProvider
    /// </summary>
    public async Task UpdateBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] childrenIds
    )
    {
        var serviceProvider = await _context
            .ServiceProviders.Include(t => t.Bookings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (serviceProvider == null)
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

        serviceProvider.Bookings = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a Review record for ServiceProvider
    /// </summary>
    public async Task<Review> GetReview(ServiceProviderWhereUniqueInput uniqueId)
    {
        var serviceProvider = await _context
            .ServiceProviders.Where(serviceProvider => serviceProvider.Id == uniqueId.Id)
            .Include(serviceProvider => serviceProvider.Review)
            .FirstOrDefaultAsync();
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }
        return serviceProvider.Review.ToDto();
    }

    /// <summary>
    /// Connect multiple Reviews records to ServiceProvider
    /// </summary>
    public async Task ConnectReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Reviews);

        foreach (var child in childrenToConnect)
        {
            parent.Reviews.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Reviews records from ServiceProvider
    /// </summary>
    public async Task DisconnectReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Reviews?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Reviews records for ServiceProvider
    /// </summary>
    public async Task<List<Review>> FindReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewFindManyArgs serviceProviderFindManyArgs
    )
    {
        var reviews = await _context
            .Reviews.Where(m => m.ServiceProviderId == uniqueId.Id)
            .ApplyWhere(serviceProviderFindManyArgs.Where)
            .ApplySkip(serviceProviderFindManyArgs.Skip)
            .ApplyTake(serviceProviderFindManyArgs.Take)
            .ApplyOrderBy(serviceProviderFindManyArgs.SortBy)
            .ToListAsync();

        return reviews.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Reviews records for ServiceProvider
    /// </summary>
    public async Task UpdateReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] childrenIds
    )
    {
        var serviceProvider = await _context
            .ServiceProviders.Include(t => t.Reviews)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reviews.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        serviceProvider.Reviews = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple ServiceCategories records to ServiceProvider
    /// </summary>
    public async Task ConnectServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.ServiceCategories)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceCategories.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ServiceCategories);

        foreach (var child in childrenToConnect)
        {
            parent.ServiceCategories.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ServiceCategories records from ServiceProvider
    /// </summary>
    public async Task DisconnectServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .ServiceProviders.Include(x => x.ServiceCategories)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceCategories.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ServiceCategories?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ServiceCategories records for ServiceProvider
    /// </summary>
    public async Task<List<ServiceCategory>> FindServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryFindManyArgs serviceProviderFindManyArgs
    )
    {
        var serviceCategories = await _context
            .ServiceCategories.Where(m => m.ServiceProviderId == uniqueId.Id)
            .ApplyWhere(serviceProviderFindManyArgs.Where)
            .ApplySkip(serviceProviderFindManyArgs.Skip)
            .ApplyTake(serviceProviderFindManyArgs.Take)
            .ApplyOrderBy(serviceProviderFindManyArgs.SortBy)
            .ToListAsync();

        return serviceCategories.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ServiceCategories records for ServiceProvider
    /// </summary>
    public async Task UpdateServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] childrenIds
    )
    {
        var serviceProvider = await _context
            .ServiceProviders.Include(t => t.ServiceCategories)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (serviceProvider == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceCategories.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        serviceProvider.ServiceCategories = children;
        await _context.SaveChangesAsync();
    }
}
