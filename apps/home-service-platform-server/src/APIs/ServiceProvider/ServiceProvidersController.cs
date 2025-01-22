using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class ServiceProvidersController : ServiceProvidersControllerBase
{
    public ServiceProvidersController(IServiceProvidersService service)
        : base(service) { }
}
