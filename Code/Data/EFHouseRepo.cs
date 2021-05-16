using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyCarbonFootprintCalculator.Data
{
    
    public class EFHouseRepo : IHouseRepo
    {
        private MyCarbonFootprintCalculatorContext _context;
        public EFHouseRepo(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }
        public IEnumerable<HouseMod> HouseList => _context.House;
    }
}
