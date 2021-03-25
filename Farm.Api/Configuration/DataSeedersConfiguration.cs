using Farm.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Farm.Api.Configuration
{
    public static class DataSeedersConfiguration
    {
        public static async Task SeedDatabase(this IServiceProvider serviceCollection)
        {
            var seedersType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name.Contains("Seeder") && t.GetInterfaces().Contains(typeof(ISeeder)));

            List<ISeeder> seeders = new List<ISeeder>();

            foreach (var seeder in seedersType)
            {
                seeders.Add((ISeeder)serviceCollection.GetService(seeder));
            }

            foreach (var seeder in seeders)
            {
                await Seed(seeder);
            }

            foreach (var seeder in seeders)
            {
                await Relate(seeder);
            }
        }

        private static async Task Seed(ISeeder serviceSeeder)
        {
            await serviceSeeder.Seed();
        }

        // Uncomment to seed relations.
        private static async Task Relate(ISeeder serviceSeeder)
        {
            //await serviceSeeder.Relate();
        }
    }
}
