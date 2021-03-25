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
            //var relatorEntities = RelatorService.GetAll().ToList();

            //foreach (var entity in relatorEntities)
            //{
            //    entity.EquipmentFarmland = new List<EquipmentFarmland> 
            //    { 
            //        new EquipmentFarmland
            //        {
            //            EquipmentPk = Entities.Value.FirstOrDefault().Pk,
            //            FarmlandPk = entity.Pk,
            //            Equipment = Entities.Value.FirstOrDefault(),
            //            Farmland = entity,
            //            OwnerShipType = OwnershipType.Own
            //        },

            //        new EquipmentFarmland
            //        {
            //            EquipmentPk = Entities.Value.LastOrDefault().Pk,
            //            FarmlandPk = entity.Pk,
            //            Equipment = Entities.Value.LastOrDefault(),
            //            Farmland = entity,
            //            OwnerShipType = OwnershipType.Rent
            //        }
            //    };

            //    RelatorService.Update(entity.Pk, entity);
            //}

            return Task.CompletedTask;
        }
    }
}
