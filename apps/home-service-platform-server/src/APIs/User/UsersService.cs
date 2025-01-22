using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(HomeServicePlatformDbContext context)
        : base(context) { }
}
