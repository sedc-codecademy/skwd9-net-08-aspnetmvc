using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using System.Linq;

namespace SEDC.PizzaApp.Services
{
    public class PizzaService
    {
        public Pizza GetPizzaById(int id)
        {
            StaticDb database = new StaticDb();
            Pizza pizza = database.Pizzas.SingleOrDefault(q => q.Id.Equals(id));
            return pizza;
        }
    }
}
