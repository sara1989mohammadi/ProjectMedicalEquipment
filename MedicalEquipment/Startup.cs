using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MedicalEquipment.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalEquipment
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddMvc();
            services.AddDbContext<MedicalEquipmentContext>(Options =>
           Options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                  .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    options => { options.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(ShareResource));
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseCookiePolicy();

            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("fa-IR"),
                new CultureInfo("en-US")
            };
            var options = new RequestLocalizationOptions()
            {
                
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            };
            app.UseRequestLocalization(options);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
          name: "areas",
          template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
