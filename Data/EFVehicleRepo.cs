using MyCarbonFootprintCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Data
{
    public class EFVehicleRepo : IVehicleRepo
    {
        private MyCarbonFootprintCalculatorContext _context;
        public EFVehicleRepo(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }
        public IEnumerable<VehicleMod> VehicleList => _context.Vehicle;   
    }
}
