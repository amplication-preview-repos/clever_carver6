using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using HomeServicePlatform.APIs.Extensions;
using HomeServicePlatform.Infrastructure;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.APIs;

public abstract class BookingsServiceBase : IBookingsService
{
    protected readonly HomeServicePlatformDbContext _context;

    public BookingsServiceBase(HomeServicePlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Booking
    /// </summary>
    public async Task<Booking> CreateBooking(BookingCreateInput createDto)
    {
        var booking = new BookingDbModel
        {
            BookingDate = createDto.BookingDate,
            CreatedAt = createDto.CreatedAt,
            PaymentStatus = createDto.PaymentStatus,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            booking.Id = createDto.Id;
        }
        if (createDto.ServiceCategory != null)
        {
            booking.ServiceCategory = await _context
                .ServiceCategories.Where(serviceCategory =>
                    createDto.ServiceCategory.Id == serviceCategory.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.ServiceProvider != null)
        {
            booking.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    createDto.ServiceProvider.Id == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.ServiceProviders != null)
        {
            booking.ServiceProviders = await _context
                .ServiceProviders.Where(serviceProvider =>
                    createDto.ServiceProviders.Select(t => t.Id).Contains(serviceProvider.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            booking.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Users != null)
        {
            booking.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BookingDbModel>(booking.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Booking
    /// </summary>
    public async Task DeleteBooking(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context.Bookings.FindAsync(uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Bookings
    /// </summary>
    public async Task<List<Booking>> Bookings(BookingFindManyArgs findManyArgs)
    {
        var bookings = await _context
            .Bookings.Include(x => x.ServiceProvider)
            .Include(x => x.ServiceCategory)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return bookings.ConvertAll(booking => booking.ToDto());
    }

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    public async Task<MetadataDto> BookingsMeta(BookingFindManyArgs findManyArgs)
    {
        var count = await _context.Bookings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Booking
    /// </summary>
    public async Task<Booking> Booking(BookingWhereUniqueInput uniqueId)
    {
        var bookings = await this.Bookings(
            new BookingFindManyArgs { Where = new BookingWhereInput { Id = uniqueId.Id } }
        );
        var booking = bookings.FirstOrDefault();
        if (booking == null)
        {
            throw new NotFoundException();
        }

        return booking;
    }

    /// <summary>
    /// Update one Booking
    /// </summary>
    public async Task UpdateBooking(BookingWhereUniqueInput uniqueId, BookingUpdateInput updateDto)
    {
        var booking = updateDto.ToModel(uniqueId);

        if (updateDto.ServiceCategory != null)
        {
            booking.ServiceCategory = await _context
                .ServiceCategories.Where(serviceCategory =>
                    updateDto.ServiceCategory == serviceCategory.Id
                )
                .FirstOrDefaultAsync();
        }

        if (updateDto.ServiceProvider != null)
        {
            booking.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    updateDto.ServiceProvider == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        if (updateDto.ServiceProviders != null)
        {
            booking.ServiceProviders = await _context
                .ServiceProviders.Where(serviceProvider =>
                    updateDto.ServiceProviders.Select(t => t).Contains(serviceProvider.Id)
                )
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            booking.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Users != null)
        {
            booking.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        _context.Entry(booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Bookings.Any(e => e.Id == booking.Id))
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
    /// Get a ServiceCategory record for Booking
    /// </summary>
    public async Task<ServiceCategory> GetServiceCategory(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.ServiceCategory)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.ServiceCategory.ToDto();
    }

    /// <summary>
    /// Get a ServiceProvider record for Booking
    /// </summary>
    public async Task<ServiceProvider> GetServiceProvider(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.ServiceProvider)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.ServiceProvider.ToDto();
    }

    /// <summary>
    /// Connect multiple ServiceProviders records to Booking
    /// </summary>
    public async Task ConnectServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Bookings.Include(x => x.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ServiceProviders);

        foreach (var child in childrenToConnect)
        {
            parent.ServiceProviders.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ServiceProviders records from Booking
    /// </summary>
    public async Task DisconnectServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Bookings.Include(x => x.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ServiceProviders?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ServiceProviders records for Booking
    /// </summary>
    public async Task<List<ServiceProvider>> FindServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderFindManyArgs bookingFindManyArgs
    )
    {
        var serviceProviders = await _context
            .ServiceProviders.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return serviceProviders.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ServiceProviders records for Booking
    /// </summary>
    public async Task UpdateServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        booking.ServiceProviders = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a User record for Booking
    /// </summary>
    public async Task<User> GetUser(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.User)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.User.ToDto();
    }

    /// <summary>
    /// Connect multiple Users records to Booking
    /// </summary>
    public async Task ConnectUsers(
        BookingWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Bookings.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Users);

        foreach (var child in childrenToConnect)
        {
            parent.Users.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Users records from Booking
    /// </summary>
    public async Task DisconnectUsers(
        BookingWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Bookings.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Users?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Users records for Booking
    /// </summary>
    public async Task<List<User>> FindUsers(
        BookingWhereUniqueInput uniqueId,
        UserFindManyArgs bookingFindManyArgs
    )
    {
        var users = await _context
            .Users.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Users records for Booking
    /// </summary>
    public async Task UpdateUsers(
        BookingWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        booking.Users = children;
        await _context.SaveChangesAsync();
    }
}
