using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SEDC.AspNet.Mvc.MyFirstApp
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //        name: "test_route2",
                //        pattern: "{controller}/{action}"
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route",
                //        pattern: "sedctest/get-data/",
                //        defaults: new { controller = "SedcTest", action = "GetData" }
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route1",
                //        pattern: "sedc/read-post/{id:int}",
                //        defaults: new { controller = "SedcTest", action = "ReadPostById" }
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route3",
                //        pattern: "sedc/read-post/{name:alpha}",
                //        defaults: new { controller = "SedcTest", action = "ReadPostByName" }
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route4",
                //        pattern: "sedc/read-post/{name:alpha:minlength(6)}",
                //        defaults: new { controller = "SedcTest", action = "ReadPostByName" }
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route5_same_as_test_route3",
                //        pattern: "{controller}/read-post/{name}",
                //        defaults: new { controller = "SedcTest", action = "ReadPostByName" },
                //        constraints: new { Name = new AlphaRouteConstraint() }
                //    );

                //endpoints.MapControllerRoute(
                //        name: "test_route6_same_as_test_route4",
                //        pattern: "{controller}/read-post/{name}",
                //        defaults: new { controller = "SedcTest", action = "ReadPostByName" },
                //        constraints: new { Name = new CompositeRouteConstraint(
                //                new IRouteConstraint[]
                //                {
                //                    new AlphaRouteConstraint(),
                //                    new MinLengthRouteConstraint(6)
                //                }
                //            ) }
                //    );
            });
        }
    }
}
