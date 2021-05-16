﻿using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    interface IFoodRepo
    {
        IEnumerable<FoodMod> FoodList { get; }
    }
}
