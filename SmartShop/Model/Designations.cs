using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
    public class Designations : BaseEntity
    {
        [Required(ErrorMessage = "Designation code is required field.")]
        [StringLength(maximumLength: 50)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Designation name is required field.")]
        [StringLength(maximumLength: 80)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation description is required field.")]
        [StringLength(maximumLength: 150)]
        public string Description { get; set; }
    }
}
