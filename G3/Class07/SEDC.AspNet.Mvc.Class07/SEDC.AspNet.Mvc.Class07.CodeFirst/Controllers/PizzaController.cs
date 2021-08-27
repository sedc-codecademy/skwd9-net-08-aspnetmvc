using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Controllers
{
    [Route("pizza")]
    public class PizzaController : Controller
    {
        private readonly PizzaContext _pizzaContext;

        public PizzaController(PizzaContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            var pizzas = _pizzaContext.Pizzas.ToList();

            return Json(pizzas);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _pizzaContext.Pizzas.FirstOrDefault(x => x.Id == id);

            return Json(pizza);
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            //var users = _pizzaContext.Users.ToList();

            //var users = _pizzaContext.Users.Where(x => x.FirstName.Contains("Trajan")).ToList();

            var users = _pizzaContext.Users.Include(x => x.Address).Include(x => x.Subscription).ToList();

            return Json(users);
        }
    }
}
