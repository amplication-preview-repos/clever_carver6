using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class AdminsService : AdminsServiceBase
{
    public AdminsService(HomeServicePlatformDbContext context)
        : base(context) { }
}
