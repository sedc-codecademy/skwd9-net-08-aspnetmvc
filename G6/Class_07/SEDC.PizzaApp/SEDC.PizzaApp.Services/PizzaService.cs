using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using System.Linq;

namespace SEDC.PizzaApp.Services
{
    public class PizzaService
    {
        public Pizza GetPizzaById(int id)
        {
            Pizza pizza = StaticDb.Pizzas.SingleOrDefault(q => q.Id.Equals(id));
            return pizza;
        }
    }
}
