using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private const string _currency = "C2";

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public MenuVM GetMenu()
        {
            var pizzas = _pizzaRepository.GetAll();

            List<PizzaVM> listOfPizzas = new List<PizzaVM>();
            foreach (var pizza in pizzas)
            {
                listOfPizzas.Add(PizzaVM.Map(pizza));
            }

            listOfPizzas = listOfPizzas
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Size)
                .ToList();

            // Linq
            //var pizzasMapped = pizzas
            //    .Select(x => PizzaVM.Map(x))
            //    .OrderBy(x => x.Name)
            //    .ThenBy(x => x.Size)
            //    .ToList();

            return new MenuVM
            {
                 Pizzas = listOfPizzas,
                 Currency = _currency
            };
        }
    }
}
