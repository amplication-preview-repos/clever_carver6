using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class BookingsService : BookingsServiceBase
{
    public BookingsService(HomeServicePlatformDbContext context)
        : base(context) { }
}
