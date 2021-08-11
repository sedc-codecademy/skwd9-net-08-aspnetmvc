using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("Title", "Pizza Home Page");
            ViewData.Add("NumberOfApp", 12);

            var firstPizza = StaticDB.Pizzas.First();
            //ViewData.Add("Pizza", firstPizza);

            ViewBag.Name = "SEDC Academy";
            ViewBag.NumberOfPizzas = 2;
            ViewBag.Pizza = firstPizza;

            return View();
        }
    }
}
