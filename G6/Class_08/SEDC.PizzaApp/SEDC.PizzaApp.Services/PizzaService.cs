using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services
{
    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<Pizza> GetAllPizzas()
        {
            return _pizzaRepository.GetAll();
        }

        public Pizza GetPizzaById(int id)
        {
            return _pizzaRepository.GetById(id);
        }
    }
}
