using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Repositories.EFEntityRepositories;
using SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services;

namespace SEDC.PizzaApp
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
            services.AddControllersWithViews();

            services.AddDbContext<PizzaDbContext>
                (
                    x => x.UseSqlServer("Server=BTL-LJUBE-BAJR1\\SQLEXPRESS;Database=PizzaDb;Trusted_Connection=True")
                );

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IPizzaOrderService, PizzaOrderService>();

            // This Reposritories work with StaticDB. If you uncomment this comment below
            //services.AddTransient<IRepository<User>, UserEntityRepository>();
            //services.AddTransient<IRepository<Pizza>, PizzaEntityRepository>();
            //services.AddTransient<IRepository<Order>, OrderEntityRepository>();

            // This Reposritories work with SQLDB. If you uncomment this comment above
            services.AddTransient<IRepository<User>, UserEFEntityRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaEFEntityRepository>();
            services.AddTransient<IRepository<Order>, OrderEFEntityRepository>();
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
    }
}
