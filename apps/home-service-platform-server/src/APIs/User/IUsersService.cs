using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;

namespace HomeServicePlatform.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Get a Booking record for User
    /// </summary>
    public Task<Booking> GetBooking(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Bookings records to User
    /// </summary>
    public Task ConnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Disconnect multiple Bookings records from User
    /// </summary>
    public Task DisconnectBookings(
        UserWhereUniqueInput uniqueId,
        BookingWhereUniqueInput[] bookingsId
    );

    /// <summary>
    /// Find multiple Bookings records for User
    /// </summary>
    public Task<List<Booking>> FindBookings(
        UserWhereUniqueInput uniqueId,
        BookingFindManyArgs BookingFindManyArgs
    );

    /// <summary>
    /// Update multiple Bookings records for User
    /// </summary>
    public Task UpdateBookings(UserWhereUniqueInput uniqueId, BookingWhereUniqueInput[] bookingsId);

    /// <summary>
    /// Get a Review record for User
    /// </summary>
    public Task<Review> GetReview(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Reviews records to User
    /// </summary>
    public Task ConnectReviews(UserWhereUniqueInput uniqueId, ReviewWhereUniqueInput[] reviewsId);

    /// <summary>
    /// Disconnect multiple Reviews records from User
    /// </summary>
    public Task DisconnectReviews(
        UserWhereUniqueInput uniqueId,
        ReviewWhereUniqueInput[] reviewsId
    );

    /// <summary>
    /// Find multiple Reviews records for User
    /// </summary>
    public Task<List<Review>> FindReviews(
        UserWhereUniqueInput uniqueId,
        ReviewFindManyArgs ReviewFindManyArgs
    );

    /// <summary>
    /// Update multiple Reviews records for User
    /// </summary>
    public Task UpdateReviews(UserWhereUniqueInput uniqueId, ReviewWhereUniqueInput[] reviewsId);
}
