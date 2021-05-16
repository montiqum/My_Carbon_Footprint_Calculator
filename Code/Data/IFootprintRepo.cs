using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    interface IFootprintRepo
    {
        IEnumerable<FootprintMod> FootprintList { get; }
    }
}
