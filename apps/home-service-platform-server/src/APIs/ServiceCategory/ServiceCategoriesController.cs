using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class ServiceCategoriesController : ServiceCategoriesControllerBase
{
    public ServiceCategoriesController(IServiceCategoriesService service)
        : base(service) { }
}
