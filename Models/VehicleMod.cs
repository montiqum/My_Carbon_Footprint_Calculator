using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Models
{
    public class VehicleMod
    {
        [Key]
        public int VehicleId { get; set; }
        public int NoOfVehicles { get; set; }
        [Required]
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [Required]
        public int Mileage { get; set; }
    }
}
