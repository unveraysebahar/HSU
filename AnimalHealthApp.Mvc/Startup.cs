using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AnimalHealthApp.Mvc.AutoMapper.Profiles;
using AnimalHealthApp.Mvc.Helpers.Abstract;
using AnimalHealthApp.Mvc.Helpers.Concrete;
using AnimalHealthApp.Services.AutoMapper.Profiles;
using AnimalHealthApp.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHealthApp.Mvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt => 
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // JsonNamingPolicy.CamelCase
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }); // We will be able to see the operations without compiling.
            services.AddSession();
            services.AddAutoMapper(typeof(VeterinaryClinicProfile), typeof(AnimalProfile), typeof(UserProfile));
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "AnimalHealthApp",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict, // Cross Side Request Forgery (CSRF) saldırısını önlemek için.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest // ALWAYS YAP UNUTMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7); // Cookie bilgileri 7 gün boyunca etkili olacak tarayıcı üzerinde
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // 404
            }
            app.UseSession();
            app.UseStaticFiles(); // Picture, CSS, JavaScript files...
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    ); 
                endpoints.MapDefaultControllerRoute(); // Go to home controller, index
            });
        }
    }
}
