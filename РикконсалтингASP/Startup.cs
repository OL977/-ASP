using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using РикконсалтингASP.Models;



namespace РикконсалтингASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
       
        {
            //var builder = new ConfigurationBuilder()               
            //    .AddJsonFile("appsettings.json,optional: true, reloadOnChange: true");

            //Configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<IdentDb>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Identity")));

            services.AddIdentity<User, IdentityRole>()
                 .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentDb>();

            services.AddDbContext<DbAll>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Рик")));

            services.AddDbContext<DbLemel>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Lemel")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //var builder = services.AddIdentityCore<User>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //identityBuilder.AddEntityFrameworkStores<IdentDb>();
            //identityBuilder.AddSignInManager<SignInManager<User>>();

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;

                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
                 //Добавляет автообновление изменения в браузер

                 //.AddNewtonsoftJson();

            //services.AddOptions(); /*это надо для json*/

            //// Add our Config object so it can be injected
            //services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));  /*это надо для json конфигурации*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default1",
                    pattern: "{controller=Start}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}
