using Farm.DAL.Interfaces;
using Farm.Data.Models;

namespace Farm.Api.Services
{
    public class FarmlandsService : BaseService<Farmland>
    {
        public FarmlandsService(IFarmDbContext context) : base (context)
        {
        }
    }
}
