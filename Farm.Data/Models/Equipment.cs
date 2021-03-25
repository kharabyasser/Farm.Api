using Farm.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farm.Data.Models
{
    public class Equipment : BaseEntity
    {
        public EquipmentType Type { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<EquipmentFarmland> EquipmentFarmlands { get; set; }
    }
}
