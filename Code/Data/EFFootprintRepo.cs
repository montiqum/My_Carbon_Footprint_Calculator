using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    public class EFFootprintRepo : IFootprintRepo
    {
        private MyCarbonFootprintCalculatorContext _context;
        public EFFootprintRepo(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }
        public IEnumerable<FootprintMod> FootprintList => _context.Footprint;        
    }
}
