using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Helpers
{
    public static class DomainModule
    {
        public static IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PizzaContext>(
                    x => x.UseLazyLoadingProxies().UseSqlServer(connectionString)
                );

            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            services.AddTransient<IRepository<Feedback>, FeedbackRepository>();

            return services;
        }
    }
}
