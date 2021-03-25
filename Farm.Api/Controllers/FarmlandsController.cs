using Farm.Api.Interfaces;
using Farm.Api.Services;
using Farm.Data.Models;
using Farm.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm.Api.Controllers
{
    public class FarmlandsController : BaseController<Farmland, IService<Farmland>>
    {
        public EquipmentsService _equipmentsService { get; set; }
        public UsersService _usersService { get; set; }

        public FarmlandsController(FarmlandsService service, EquipmentsService equipmentsService, UsersService usersService) 
            : base(service)
        {
            _equipmentsService = equipmentsService;
            _usersService = usersService;
        }

        /// <summary>
        /// Assign Equipemt to Faramland.
        /// </summary>
        /// <param name="farmlandPk"></param>
        /// <param name="equipmentPk"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        [Route("/api/farmlands/assignEquipment/{farmlandPk}/{equipmentPk}/{relation}")]
        [HttpPost]
        public ActionResult<Farmland> AssignEquipment(Guid farmlandPk, Guid equipmentPk, string relation)
        {
            var farmland = _entityService.GetById(farmlandPk);
            var equipment = _equipmentsService.GetById(equipmentPk);

            if (farmland != null && equipment != null)
            {
                var equipmentFarmland = new EquipmentFarmland
                {
                    EquipmentId = equipmentPk,
                    FarmlandId = farmlandPk,
                    Equipment = equipment,
                    Farmland = farmland,
                    OwnerShipType = (OwnershipType)Enum.Parse(typeof(OwnershipType), relation, true)
                };

                if (farmland.EquipmentFarmlands != null)
                {
                    farmland.EquipmentFarmlands.Add(equipmentFarmland);
                }
                else
                {
                    farmland.EquipmentFarmlands = new List<EquipmentFarmland>
                    {
                        equipmentFarmland
                    };
                }

                _entityService.Update(farmland.Id, farmland);
            }

            return new OkResult();
        }

        /// <summary>
        /// Assign a User to Farmland.
        /// </summary>
        /// <param name="farmlandPk"></param>
        /// <param name="userPk"></param>
        /// <returns></returns>
        [Route("/api/farmlands/assignUser/{farmlandPk}/{userPk}")]
        [HttpPost]
        public ActionResult<Farmland> AssignUser(Guid farmlandPk, Guid userPk)
        {
            var farmland = _entityService.GetById(farmlandPk);
            var user = _usersService.GetById(userPk);

            if (farmland != null && user != null)
            {
                if (farmland.Farmers != null)
                {
                    farmland.Farmers.Add(user);
                }
                else
                {
                    farmland.Farmers = new List<User>
                    {
                        user
                    };
                }

                _entityService.Update(farmland.Id, farmland);
            }

            return new OkResult();
        }

        /// <summary>
        /// Get Farmlands by user.
        /// </summary>
        /// <param name="userPk"></param>
        /// <returns></returns>
        [Route("/api/farmlands/{userPk}")]
        [HttpGet]
        public ActionResult<IEnumerable<Farmland>> GetFarmsByUser(Guid userPk)
        {
            var result = _entityService.FindBy(f => f.Farmers.Any(u => u.Id.Equals(userPk)));

            return new ObjectResult(result);
        }
    }
}
