using MarsWearShop.Data;
using MarsWearShop.Interfaces;
using MarsWearShop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop
{
    public class Startup
    {
        readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DbConnectStr")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts => {
                opts.LoginPath = "/";
                opts.AccessDeniedPath = "/";
            });

            services.AddHttpContextAccessor();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRequestLocalization("en-US");
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseSession();
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(opts => {
                opts.MapControllerRoute("Default", "{controller=home}/{action=index}");
                opts.MapControllerRoute("Admin", "{area:exists}/{controller=order}/{action=list}");
            });
        }
    }
}
