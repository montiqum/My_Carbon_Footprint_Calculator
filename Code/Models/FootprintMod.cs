using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Models
{
    public class FootprintMod
    {
        [Key]
        public int CFPId { get; set; }
        [Required]
        public int Travel_emm { get; set; }
        [Required]
        public int HH_Emm { get; set; }
        [Required]
        public int Waste_emm { get; set; }
        [Required]
        public int Total_emm { get; set; }
    }
}
