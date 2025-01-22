using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class ServiceCategoriesService : ServiceCategoriesServiceBase
{
    public ServiceCategoriesService(HomeServicePlatformDbContext context)
        : base(context) { }
}
