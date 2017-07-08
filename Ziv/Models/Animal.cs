using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ziv.Models
{
    public abstract class Animal
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Name cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public decimal Weight { get; set; }
        public string Discriminator { get; set; }
    }
}
