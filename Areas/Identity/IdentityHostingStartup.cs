using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using osnet.Areas.Identity.Data;

[assembly: HostingStartup(typeof(osnet.Areas.Identity.IdentityHostingStartup))]
namespace osnet.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<osnetIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("osnetIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<osnetIdentityDbContext>();
            });
        }
    }
}