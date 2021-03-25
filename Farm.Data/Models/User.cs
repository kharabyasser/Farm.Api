using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farm.Data.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Farmland> WorkingFarms { get; set; }
    }
}
