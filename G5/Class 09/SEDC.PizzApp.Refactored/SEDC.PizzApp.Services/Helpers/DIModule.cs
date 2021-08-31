using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.DataAccess.Repositories.CacheRepositories;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.Services.Helpers
{
   public static class DIModule
   {
      public static IServiceCollection RegisterRepositories(IServiceCollection services)
      {
         services.AddTransient<IRepository<User>, UserRepository>();
         services.AddTransient<IRepository<Feedback>, FeedbackRepository>();
         services.AddTransient<IRepository<Pizza>, PizzaRepository>();
         services.AddTransient<IRepository<Order>, OrderRepository>();

         return services;
      }
   }
}