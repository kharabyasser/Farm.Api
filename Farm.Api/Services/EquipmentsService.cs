using Farm.DAL.Interfaces;
using Farm.Data.Models;

namespace Farm.Api.Services
{
    public class EquipmentsService : BaseService<Equipment>
    {
        public EquipmentsService(IFarmDbContext context) : base (context)
        {
        }
    }
}
