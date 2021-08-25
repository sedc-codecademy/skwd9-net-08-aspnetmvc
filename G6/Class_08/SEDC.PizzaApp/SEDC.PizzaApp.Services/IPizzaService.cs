using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services
{
    public interface IPizzaService
    {
        public List<Pizza> GetAllPizzas();

        public Pizza GetPizzaById(int id);

        public List<Pizza> GetPizzasForMenu();
    }
}
