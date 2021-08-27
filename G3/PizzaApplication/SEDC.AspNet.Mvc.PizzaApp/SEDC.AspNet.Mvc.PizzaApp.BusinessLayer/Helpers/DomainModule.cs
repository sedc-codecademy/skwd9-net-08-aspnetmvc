using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Helpers
{
    public static class DomainModule
    {
        public static IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PizzaContext>(
                    x => x.UseSqlServer(connectionString)
                );

            return services;
        }
    }
}
