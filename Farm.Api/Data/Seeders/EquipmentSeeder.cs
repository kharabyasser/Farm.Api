using Farm.Api.Interfaces;
using Farm.DAL.Interfaces;
using Farm.Data.Models;
using Farm.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Api.Data.Seeders
{
    public class EquipmentSeeder : BaseSeeder<Equipment>, ISeeder
    {
        private IService<Farmland> RelatorService { get; }

        public EquipmentSeeder(IFarmDbContext context, FarmlandsSeeder relatorService) : base(context)
        {
            Entities = new Lazy<IEnumerable<Equipment>>(() => new List<Equipment>
            {
                new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = "IF - SEEDER 731",
                    Type = EquipmentType.Seeder
                },

                new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = "IF - SPRAYER 91",
                    Type = EquipmentType.Sprayer
                },

                 new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = "IF - TRACKTOR 061",
                    Type = EquipmentType.Tracktor
                },
            });

            RelatorService = relatorService;
        }

        public Task Relate()
        {
            var relatorEntities = RelatorService.GetAll().ToList();

            foreach (var entity in relatorEntities)
            {
                entity.EquipmentFarmlands = new List<EquipmentFarmland>
                {
                    new EquipmentFarmland
                    {
                        EquipmentId = Entities.Value.FirstOrDefault().Id,
                        FarmlandId = entity.Id,
                        Equipment = Entities.Value.FirstOrDefault(),
                        Farmland = entity,
                        OwnerShipType = OwnershipType.Own
                    },

                    new EquipmentFarmland
                    {
                        EquipmentId = Entities.Value.LastOrDefault().Id,
                        FarmlandId = entity.Id,
                        Equipment = Entities.Value.LastOrDefault(),
                        Farmland = entity,
                        OwnerShipType = OwnershipType.Rent
                    }
                };

                RelatorService.Update(entity.Id, entity);
            }

            return Task.CompletedTask;
        }
    }
}
