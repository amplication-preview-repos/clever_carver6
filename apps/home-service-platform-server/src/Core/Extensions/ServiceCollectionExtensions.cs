using HomeServicePlatform.APIs;

namespace HomeServicePlatform;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAdminsService, AdminsService>();
        services.AddScoped<IBookingsService, BookingsService>();
        services.AddScoped<IReviewsService, ReviewsService>();
        services.AddScoped<IServiceCategoriesService, ServiceCategoriesService>();
        services.AddScoped<IServiceProvidersService, ServiceProvidersService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
