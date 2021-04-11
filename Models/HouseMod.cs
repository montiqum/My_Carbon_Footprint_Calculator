using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarbonFootprintCalculator.Models
{
    public class HouseMod
    {
        [Key]
        public int HouseId { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
        public int Energy_Usage { get; set; }
        [Required]
        public string Energy_Type { get; set; }
    }
}
