using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class AdminsController : AdminsControllerBase
{
    public AdminsController(IAdminsService service)
        : base(service) { }
}
