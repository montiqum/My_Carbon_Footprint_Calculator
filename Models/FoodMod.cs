using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Models
{
    public class FoodMod
    {
        [Key]
        public int DietId { get; set; }
        [Required]
        public string DietType { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
