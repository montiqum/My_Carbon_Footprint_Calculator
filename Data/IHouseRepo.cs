using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCarbonFootprintCalculator.Models;

namespace MyCarbonFootprintCalculator.Data
{
    interface IHouseRepo
    {
        IEnumerable<HouseMod> HouseList { get; }
    }
}
