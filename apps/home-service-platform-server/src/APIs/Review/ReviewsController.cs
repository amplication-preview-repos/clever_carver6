using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class ReviewsController : ReviewsControllerBase
{
    public ReviewsController(IReviewsService service)
        : base(service) { }
}
