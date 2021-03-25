using Farm.DAL.Interfaces;
using Farm.Data.Models;

namespace Farm.Api.Services
{
    public class UsersService : BaseService<User>
    {
        public UsersService(IFarmDbContext context) : base (context)
        {
        }
    }
}
