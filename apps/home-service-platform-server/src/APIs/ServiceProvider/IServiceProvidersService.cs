using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;

namespace HomeServicePlatform.APIs;

public interface IServiceProvidersService
{
    /// <summary>
    /// Create one ServiceProvider
    /// </summary>
    public Task<ServiceProvider> CreateServiceProvider(ServiceProviderCreateInput serviceprovider);

    /// <summary>
    /// Delete one ServiceProvider
    /// </summary>
    public Task DeleteServiceProvider(ServiceProviderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceProviders
    /// </summary>
    public Task<List<ServiceProvider>> ServiceProviders(ServiceProviderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ServiceProvider records
    /// </summary>
    public Task<MetadataDto> ServiceProvidersMeta(ServiceProviderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceProvider
    /// </summary>
    public Task<ServiceProvider> ServiceProvider(ServiceProviderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceProvider
    /// </summary>
    public Task UpdateServiceProvider(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceProviderUpdateInput updateDto
    );

    /// <summary>
    /// Get a Booking record for ServiceProvider
    /// </summary>
    public Task<Booking> GetBooking(ServiceProviderWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Bookings records to ServiceProvider
    /// </summary>
    public Task ConnectBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Bookings records from ServiceProvider
    /// </summary>
    public Task DisconnectBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Find multiple Bookings records for ServiceProvider
    /// </summary>
    public Task<List<Booking>> FindBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Update multiple Bookings records for ServiceProvider
    /// </summary>
    public Task UpdateBookings(
        ServiceProviderWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Get a Review record for ServiceProvider
    /// </summary>
    public Task<Review> GetReview(ServiceProviderWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Reviews records to ServiceProvider
    /// </summary>
    public Task ConnectReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Disconnect multiple Reviews records from ServiceProvider
    /// </summary>
    public Task DisconnectReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Find multiple Reviews records for ServiceProvider
    /// </summary>
    public Task<List<Review>> FindReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewFindManyArgs ReviewFindManyArgs
    );

    /// <summary>
    /// Update multiple Reviews records for ServiceProvider
    /// </summary>
    public Task UpdateReviews(
        ServiceProviderWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Connect multiple ServiceCategories records to ServiceProvider
    /// </summary>
    public Task ConnectServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    );

    /// <summary>
    /// Disconnect multiple ServiceCategories records from ServiceProvider
    /// </summary>
    public Task DisconnectServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    );

    /// <summary>
    /// Find multiple ServiceCategories records for ServiceProvider
    /// </summary>
    public Task<List<ServiceCategory>> FindServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryFindManyArgs ServiceCategoryFindManyArgs
    );

    /// <summary>
    /// Update multiple ServiceCategories records for ServiceProvider
    /// </summary>
    public Task UpdateServiceCategories(
        ServiceProviderWhereUniqueInput uniqueId,
        ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    );
}
