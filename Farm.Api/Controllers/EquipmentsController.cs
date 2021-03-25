using Farm.Api.Interfaces;
using Farm.Api.Services;
using Farm.Data.Models;

namespace Farm.Api.Controllers
{
    public class EquipmentsController : BaseController<Equipment, IService<Equipment>>
    {
        public EquipmentsController(EquipmentsService service) : base(service)
        {

        }
    }
}
