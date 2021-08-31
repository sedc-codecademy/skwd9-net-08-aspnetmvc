using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzApp.DataAccess;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.DataAccess.Repositories.CacheRepositories;
using SEDC.PizzApp.DataAccess.Repositories.EntityRepositories;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.Services.Helpers
{
   public static class DIModule
   {
      public static IServiceCollection RegisterRepositories(IServiceCollection services)
      {
         services.AddDbContext<PizzaDbContext>(x =>
            x.UseSqlServer("Server=localhost; Database=PizzaDb; Trusted_Connection=True"));

         // Register repositories that communicate with actual database
         services.AddTransient<IRepository<User>, UserEntityRepository>();
         services.AddTransient<IRepository<Feedback>, FeedbackEntityRepository>();
         services.AddTransient<IRepository<Pizza>, PizzaEntityRepository>();
         services.AddTransient<IRepository<Order>, OrderEntityRepository>();

         // Cache DB example (repositories)
         //services.AddTransient<IRepository<User>, UserRepository>();
         //services.AddTransient<IRepository<Feedback>, FeedbackRepository>();
         //services.AddTransient<IRepository<Pizza>, PizzaRepository>();
         //services.AddTransient<IRepository<Order>, OrderRepository>();

         return services;
      }
   }
}