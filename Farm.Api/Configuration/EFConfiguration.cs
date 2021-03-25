using Farm.DAL;
using Farm.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farm.Api.Configuration
{
    public static class EFConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FarmDbContext>(options => options.UseInMemoryDatabase(databaseName: "FarmDb"));

            var options = new DbContextOptionsBuilder<FarmDbContext>()
                        .UseInMemoryDatabase(databaseName: "FarmDb")
                        .Options;

            services.AddSingleton<IFarmDbContext>(x => new FarmDbContext(options));
        }
    }
}
