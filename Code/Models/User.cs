using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyCarbonFootprintCalculator.Models
{
    public class User : IdentityUser<int>
    {   

        [Required]
        [MaxLength(45)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


    }
}
