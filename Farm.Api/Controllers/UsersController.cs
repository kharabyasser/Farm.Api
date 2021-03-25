using Farm.Api.Interfaces;
using Farm.Api.Services;
using Farm.Data.Models;

namespace Farm.Api.Controllers
{
    public class UsersController : BaseController<User, IService<User>>
    {
        public UsersController(UsersService service) : base(service)
        {
        }
    }
}
