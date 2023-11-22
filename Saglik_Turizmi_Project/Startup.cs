using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saglik_Turizmi_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(_ => _.UseSqlServer(Configuration["ConnectionStrings:SqlServerConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {

                options.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
                options.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
                options.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
                options.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
                options.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.

            }).AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddControllersWithViews();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                CreateUserOnStartup(scope.ServiceProvider).GetAwaiter().GetResult();
            }
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private async Task CreateUserOnStartup(IServiceProvider serviceProvider)
        {
            // UserManager'� servis sa�lay�c�dan al
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // E�er kullan�c� zaten varsa olu�turmay� tekrarlamaya gerek yok
            if (await userManager.FindByNameAsync("exampleUser") == null)
            {
                var newUser = new AppUser { UserName = "exampleUser", Email = "example@example.com" };
                await userManager.CreateAsync(newUser, "yourPassword");
                Console.WriteLine("Job �al��t�");
            }
            
        }
    }
}
