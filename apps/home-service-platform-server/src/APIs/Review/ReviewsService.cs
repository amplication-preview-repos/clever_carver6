using HomeServicePlatform.Infrastructure;

namespace HomeServicePlatform.APIs;

public class ReviewsService : ReviewsServiceBase
{
    public ReviewsService(HomeServicePlatformDbContext context)
        : base(context) { }
}
