using Microsoft.Extensions.DependencyInjection;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.Helpers
{
    public static class DiRepositoryModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
