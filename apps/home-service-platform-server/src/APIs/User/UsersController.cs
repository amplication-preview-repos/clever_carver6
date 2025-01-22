using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
