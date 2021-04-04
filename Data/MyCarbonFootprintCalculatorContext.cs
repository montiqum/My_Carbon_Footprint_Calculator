using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCarbonFootprintCalculator.Models;

namespace MyCarbonFootprintCalculator.Data
{
    public class MyCarbonFootprintCalculatorContext:DbContext
    {
        public MyCarbonFootprintCalculatorContext(DbContextOptions<MyCarbonFootprintCalculatorContext>options)
            :base(options)
        {

        }
        public DbSet<GenInfoMod> GenInfo { get; set; }
        public DbSet<HouseMod> House { get; set; }
        public DbSet<VehicleMod> Vehicle { get; set; }
        public DbSet<FoodMod> Food { get; set; }
        public DbSet<FootprintMod> Footprint { get; set; }
    }
}
