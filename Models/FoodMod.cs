using Microsoft.Web.Mvc.Controls;
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
        public int Grains { get; set; }
        public int Meat { get; set; }
        public int Vegetables { get; set; }
        public int Fruits { get; set; }
        public int Fish { get; set; }
        public int Milk { get; set; }
        public int Desserts { get; set; }
        public int Fast_foods { get; set; }

    }
}
