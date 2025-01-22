using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class BookingsController : BookingsControllerBase
{
    public BookingsController(IBookingsService service)
        : base(service) { }
}
