using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

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

        public Pizza GetPizzaByNameAndSize(string name, PizzaSize pizzaSize)
        {
            return _pizzaRepository.GetAll().FirstOrDefault(q => q.Name.Equals(name) && q.Size.Equals(pizzaSize));
        }

        public List<Pizza> GetPizzasForMenu()
        {
            return _pizzaRepository.GetAll()
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToList();
        }
    }
}
