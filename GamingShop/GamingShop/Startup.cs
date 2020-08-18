using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamingShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(x =>
            {
                x.AddPolicy("adminpolicy", p => p.RequireRole("admins"));
            });
        }
        private async Task GamingShopInitIdentity(UserManager<ApplicationUser> userManager,
                                             RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser adminuser = await userManager.FindByNameAsync("nima13727@gmail.com");
            if (adminuser == null)
            {
                adminuser = new ApplicationUser
                {
                    Name = "Nima",
                    Family = "Hosseini",
                    UserName = "KINGMAN81",
                    Email = "nima13727@gmail.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminuser, "pP=-0987");
            }
            IdentityRole adminrole = await roleManager.FindByNameAsync("admins");
            if (adminrole == null)
            {
                adminrole = new IdentityRole("admins");
                await roleManager.CreateAsync(adminrole);
                await userManager.AddToRoleAsync(adminuser, "admins");
                //await userManager.RemoveFromRoleAsync(adminuser, "admins");

            }
            IdentityRole customerrole = await roleManager.FindByNameAsync("customers");
            if (customerrole == null)
            {
                customerrole = new IdentityRole("customers");
                await roleManager.CreateAsync(customerrole);
                //await userManager.RemoveFromRoleAsync(adminuser, "admins");

            }
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            GamingShopInitIdentity(userManager, roleManager).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            //app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
