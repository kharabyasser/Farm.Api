using Farm.Data.Models.Enums;
using System;

namespace Farm.Data.Models
{
    public class EquipmentFarmland
    {
        public Guid EquipmentId { get; set; }
        public Guid FarmlandId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Farmland Farmland { get; set; }

        public OwnershipType OwnerShipType { get; set; }
    }
}
