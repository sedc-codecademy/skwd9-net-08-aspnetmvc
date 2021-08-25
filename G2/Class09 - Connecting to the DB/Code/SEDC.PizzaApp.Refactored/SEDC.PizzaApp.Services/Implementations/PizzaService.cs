using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository) //Dependency Injection
        {
            _pizzaRepository = pizzaRepository;
        }
        public List<PizzaDDViewModel> GetPizzasForDropdown()
        {
            //get from db
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();
            //map to view models
            return pizzasDb.Select(x => x.ToPizzaDDViewModel()).ToList();
        }

        public string GetPizzaOnPromotion()
        {
            return _pizzaRepository.GetPizzaOnPromotion().Name;
        }
    }
}
