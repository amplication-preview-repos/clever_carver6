using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class ServiceProvidersService : ServiceProvidersServiceBase
{
    public ServiceProvidersService(HomeServicePlatformDbContext context)
        : base(context) { }
}
