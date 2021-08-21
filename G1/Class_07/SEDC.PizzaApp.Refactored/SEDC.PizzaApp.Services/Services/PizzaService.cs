using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.CacheRepository;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Services
{
    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        //registering implementation for interface in constructor(without container)
        //public PizzaService()
        //{          
        //    _pizzaRepository = new PizzaRepository();
        //}
        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public List<Pizza> GetAllPizzas()
        {
            return _pizzaRepository.GetAll();
        }
    }
}
