using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCarbonFootprintCalculator.Areas.Identity.Data;
using MyCarbonFootprintCalculator.Data;

[assembly: HostingStartup(typeof(MyCarbonFootprintCalculator.Areas.Identity.IdentityHostingStartup))]
namespace MyCarbonFootprintCalculator.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<MyCarbonFootprintCalculatorUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false; //to set email verification
                    options.Password.RequireUppercase = false; //password require uppercase
                    options.Password.RequireLowercase = false; //password require lowercase
                })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}