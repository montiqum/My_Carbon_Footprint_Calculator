using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    public class EFFoodRepo : IFoodRepo
    {
        private MyCarbonFootprintCalculatorContext _context;
        public EFFoodRepo(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }
        public IEnumerable<FoodMod> FoodList => _context.Food;
    }
}
