using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using SEDC.PizzaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaOrderService _pizzaOrderService;

        public HomeController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            List<Pizza> menu = _pizzaOrderService.GetMenu();

            List<PizzaViewModel> pizzas = new List<PizzaViewModel>();

            foreach (var pizza in menu)
            {
                pizzas.Add(new PizzaViewModel
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Image = pizza.Image,
                    Price = pizza.Price,
                    PizzaSize = pizza.PizzaSize
                });
            }

            MenuViewModel model = new MenuViewModel
            {
                Pizzas = pizzas
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is the about page for our pizza app!";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "You can find us here!";
            return View();
        }
    }
}
