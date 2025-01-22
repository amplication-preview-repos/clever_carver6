using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;

namespace HomeServicePlatform.APIs;

public interface IServiceCategoriesService
{
    /// <summary>
    /// Create one ServiceCategory
    /// </summary>
    public Task<ServiceCategory> CreateServiceCategory(ServiceCategoryCreateInput servicecategory);

    /// <summary>
    /// Delete one ServiceCategory
    /// </summary>
    public Task DeleteServiceCategory(ServiceCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceCategories
    /// </summary>
    public Task<List<ServiceCategory>> ServiceCategories(ServiceCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ServiceCategory records
    /// </summary>
    public Task<MetadataDto> ServiceCategoriesMeta(ServiceCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceCategory
    /// </summary>
    public Task<ServiceCategory> ServiceCategory(ServiceCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceCategory
    /// </summary>
    public Task UpdateServiceCategory(
        ServiceCategoryWhereUniqueInput uniqueId,
        ServiceCategoryUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple Bookings records to ServiceCategory
    /// </summary>
    public Task ConnectBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Bookings records from ServiceCategory
    /// </summary>
    public Task DisconnectBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Find multiple Bookings records for ServiceCategory
    /// </summary>
    public Task<List<Booking>> FindBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Update multiple Bookings records for ServiceCategory
    /// </summary>
    public Task UpdateBookings(
        ServiceCategoryWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Get a ServiceProvider record for ServiceCategory
    /// </summary>
    public Task<ServiceProvider> GetServiceProvider(ServiceCategoryWhereUniqueInput uniqueId);
}
