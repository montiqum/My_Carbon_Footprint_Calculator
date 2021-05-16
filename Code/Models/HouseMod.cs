using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarbonFootprintCalculator.Models
{
    public enum energytype { solar, gas, electric }
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
        public string Energy_Type { get; set; }
        public bool Solar { get; set; }
        public bool Gas { get; set; }
        public bool Electric { get; set; }

        public string GetEnergyType(bool Solar, bool Gas, bool Electric)
        {
            if (Solar && !Gas && !Electric)
            {
                Energy_Type = "Solar";
            }
            else if (!Solar && Gas && !Electric)
            {
                Energy_Type = "Gas";
            }
            else if (!Solar && !Gas && Electric)
            {
                Energy_Type = "Electric";
            }
            else if (Solar && Gas && !Electric)
            {
                Energy_Type = "Solar and Gas";
            }
            else if (Solar && !Gas && Electric)
            {
                Energy_Type = "Solar and Electric";
            }
            else if (!Solar && Gas && Electric)
            {
                Energy_Type = "Gas and Electric";
            }
            else if (Solar && Gas && Electric)
            {
                Energy_Type = "Solar, Gas, and Electric";
            }
            else if (!Solar && !Gas && !Electric)
            {
                Energy_Type = "No value";
            }

            return Energy_Type;
        }
    }
}
