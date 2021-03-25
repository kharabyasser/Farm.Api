using System.Threading.Tasks;

namespace Farm.Api.Interfaces
{
    public interface ISeeder
    {
        Task Seed();

        Task Relate();
    }
}
