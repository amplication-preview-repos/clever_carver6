using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;

namespace HomeServicePlatform.APIs;

public interface IBookingsService
{
    /// <summary>
    /// Create one Booking
    /// </summary>
    public Task<Booking> CreateBooking(BookingCreateInput booking);

    /// <summary>
    /// Delete one Booking
    /// </summary>
    public Task DeleteBooking(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Bookings
    /// </summary>
    public Task<List<Booking>> Bookings(BookingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    public Task<MetadataDto> BookingsMeta(BookingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Booking
    /// </summary>
    public Task<Booking> Booking(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Booking
    /// </summary>
    public Task UpdateBooking(BookingWhereUniqueInput uniqueId, BookingUpdateInput updateDto);

    /// <summary>
    /// Get a ServiceCategory record for Booking
    /// </summary>
    public Task<ServiceCategory> GetServiceCategory(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a ServiceProvider record for Booking
    /// </summary>
    public Task<ServiceProvider> GetServiceProvider(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple ServiceProviders records to Booking
    /// </summary>
    public Task ConnectServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Disconnect multiple ServiceProviders records from Booking
    /// </summary>
    public Task DisconnectServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Find multiple ServiceProviders records for Booking
    /// </summary>
    public Task<List<ServiceProvider>> FindServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderFindManyArgs ServiceProviderFindManyArgs
    );

    /// <summary>
    /// Update multiple ServiceProviders records for Booking
    /// </summary>
    public Task UpdateServiceProviders(
        BookingWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Get a User record for Booking
    /// </summary>
    public Task<User> GetUser(BookingWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Users records to Booking
    /// </summary>
    public Task ConnectUsers(BookingWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Disconnect multiple Users records from Booking
    /// </summary>
    public Task DisconnectUsers(BookingWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Find multiple Users records for Booking
    /// </summary>
    public Task<List<User>> FindUsers(
        BookingWhereUniqueInput uniqueId,
        UserFindManyArgs UserFindManyArgs
    );

    /// <summary>
    /// Update multiple Users records for Booking
    /// </summary>
    public Task UpdateUsers(BookingWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);
}
