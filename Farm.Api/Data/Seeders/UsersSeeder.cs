using Farm.Api.Interfaces;
using Farm.Api.Services;
using Farm.DAL.Interfaces;
using Farm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Api.Data.Seeders
{
    public class UsersSeeder : BaseSeeder<User>, ISeeder
    {
        private FarmlandsService RelatorService { get; }

        public UsersSeeder(IFarmDbContext context, FarmlandsService relatorService) : base(context)
        {
            Entities = new Lazy<IEnumerable<User>>(() => new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Donald"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sarra",
                    LastName = "Daniel"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Marc",
                    LastName = "Subermaniam"
                },
            });

            RelatorService = relatorService;
        }

        public Task Relate()
        {
            var relatorEntities = RelatorService.GetAll().ToList();

            foreach (var entity in relatorEntities)
            {
                entity.Farmers = Entities.Value.ToList();

                var result = RelatorService.Update(entity.Id, entity);
            }

            SaveChanges();

            return Task.CompletedTask;
        }
    }
}
