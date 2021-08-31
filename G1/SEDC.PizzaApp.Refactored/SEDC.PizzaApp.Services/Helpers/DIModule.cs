using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.CacheRepository;
using SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services, string connectionString)
        {
            //registering repository services with container
            //when the app starts in startup when we register the interface, its searching for implementation
            //for registering interface with implementation, we register it on this way =>
            //=> service.AddTrainsient<Interface,Service>()
            //where the interface is the class for the Interface and Service is pointer for the class where the implementation is for =>
            //=> the interface is(service class)


            services.AddDbContext<PizzaDbContext>(x => x.UseSqlServer(connectionString));


            services.AddTransient<IRepository<User>, UserEntityRepository>();
            services.AddTransient<IRepository<Order>, OrderEntityRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaEntityRepository>();

            return services;
        }
    }
}
