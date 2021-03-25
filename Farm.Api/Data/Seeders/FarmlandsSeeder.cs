using Farm.Api.Interfaces;
using Farm.DAL.Interfaces;
using Farm.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farm.Api.Data.Seeders
{
    public class FarmlandsSeeder : BaseSeeder<Farmland>, ISeeder
    {
        public FarmlandsSeeder(IFarmDbContext context) : base(context)
        {
            Entities = new Lazy<IEnumerable<Farmland>>(() => new List<Farmland>
            {
                new Farmland
                {
                    Id = Guid.NewGuid(),
                    Location = "Albera",
                    NbAcres = 10
                },

                new Farmland
                {
                    Id = Guid.NewGuid(),
                    Location = "Vancouver",
                    NbAcres = 8
                },

                new Farmland
                {
                    Id = Guid.NewGuid(),
                    Location = "Saskatchewan",
                    NbAcres = 78
                },
            });
        }

        public Task Relate()
        {
            return Task.CompletedTask;
        }
    }
}
