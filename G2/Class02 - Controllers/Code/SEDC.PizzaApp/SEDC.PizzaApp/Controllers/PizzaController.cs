using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            return View(pizzas); //we send the list to the view
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                return new EmptyResult();
            }
            return View(pizza);
        }
        [Route("SeePizzas")] //localhost:[port]/SeePizzas
        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }
    }
}
