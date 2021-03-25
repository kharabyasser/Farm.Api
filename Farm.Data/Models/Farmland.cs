using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farm.Data.Models
{
    public class Farmland : BaseEntity
    {
        // TO-DO: Split into more specific fields for better filtering, accessebility etc...
        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(20)]
        public string Location { get; set; }

        // TO-DO: Improve nomenclature.
        public int NbAcres { get; set; }

        public virtual ICollection<EquipmentFarmland> EquipmentFarmlands { get; set; }
        public virtual ICollection<User> Farmers { get; set; }
    }
}
