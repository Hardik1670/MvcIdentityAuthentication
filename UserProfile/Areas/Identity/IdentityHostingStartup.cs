using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserProfile.Areas.Identity.Data;
using UserProfile.Data;

[assembly: HostingStartup(typeof(UserProfile.Areas.Identity.IdentityHostingStartup))]
namespace UserProfile.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserProfileContextIdentity>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserProfileContextIdentityConnection")));

                services.AddDefaultIdentity<UserProfileUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserProfileContextIdentity>();
            });
        }
    }
}