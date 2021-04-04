using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    public class EFGenInfoRepo : IGenInfoRepo
    {
        private MyCarbonFootprintCalculatorContext _context;
        public EFGenInfoRepo(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }
        public IEnumerable<GenInfoMod> GenInfoList => _context.GenInfo;    
    }
}
