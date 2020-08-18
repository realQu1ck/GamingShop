using System;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GamingShop.Areas.Identity.IdentityHostingStartup))]
namespace GamingShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

                services.AddDbContext<DBGamingShop>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DBGamingShopConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedEmail = true)
                   .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<DBGamingShop>();

                services.AddAuthentication();

                services.ConfigureApplicationCookie(x =>
                {
                    x.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = y =>
                        {
                            y.Response.Redirect($"/Account/LoginRegister?returnurl={y.Request.Path}");
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = y =>
                        {
                            y.Response.Redirect($"/Account/LoginRegister?returnurl={y.Request.Path}");
                            return Task.CompletedTask;
                        }
                    };
                });

                services.AddAuthorization(x =>
                {
                    x.AddPolicy("adminpolicy", p => p.RequireRole("admins"));
                });



                services.Configure<IdentityOptions>(x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequiredLength = 2;
                    x.Password.RequireUppercase = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequiredUniqueChars = 0;
                    x.Lockout.AllowedForNewUsers = true;
                    x.Lockout.MaxFailedAccessAttempts = 5;
                    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                });
            });

        }
    }
}