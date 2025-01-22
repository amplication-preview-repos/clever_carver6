using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;

namespace HomeServicePlatform.APIs;

public interface IReviewsService
{
    /// <summary>
    /// Create one Review
    /// </summary>
    public Task<Review> CreateReview(ReviewCreateInput review);

    /// <summary>
    /// Delete one Review
    /// </summary>
    public Task DeleteReview(ReviewWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Reviews
    /// </summary>
    public Task<List<Review>> Reviews(ReviewFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Review records
    /// </summary>
    public Task<MetadataDto> ReviewsMeta(ReviewFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Review
    /// </summary>
    public Task<Review> Review(ReviewWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Review
    /// </summary>
    public Task UpdateReview(ReviewWhereUniqueInput uniqueId, ReviewUpdateInput updateDto);

    /// <summary>
    /// Get a ServiceProvider record for Review
    /// </summary>
    public Task<ServiceProvider> GetServiceProvider(ReviewWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple ServiceProviders records to Review
    /// </summary>
    public Task ConnectServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Disconnect multiple ServiceProviders records from Review
    /// </summary>
    public Task DisconnectServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Find multiple ServiceProviders records for Review
    /// </summary>
    public Task<List<ServiceProvider>> FindServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderFindManyArgs ServiceProviderFindManyArgs
    );

    /// <summary>
    /// Update multiple ServiceProviders records for Review
    /// </summary>
    public Task UpdateServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] serviceProvidersId
    );

    /// <summary>
    /// Get a User record for Review
    /// </summary>
    public Task<User> GetUser(ReviewWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Users records to Review
    /// </summary>
    public Task ConnectUsers(ReviewWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Disconnect multiple Users records from Review
    /// </summary>
    public Task DisconnectUsers(ReviewWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);

    /// <summary>
    /// Find multiple Users records for Review
    /// </summary>
    public Task<List<User>> FindUsers(
        ReviewWhereUniqueInput uniqueId,
        UserFindManyArgs UserFindManyArgs
    );

    /// <summary>
    /// Update multiple Users records for Review
    /// </summary>
    public Task UpdateUsers(ReviewWhereUniqueInput uniqueId, UserWhereUniqueInput[] usersId);
}
