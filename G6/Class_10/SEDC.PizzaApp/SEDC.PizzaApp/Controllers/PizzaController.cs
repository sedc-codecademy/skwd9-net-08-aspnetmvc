using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Services;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            List<Pizza> pizzas = _pizzaService.GetPizzasForMenu();
            List<PizzaViewModel> viewModelPizzas = new List<PizzaViewModel>();

            foreach (Pizza item in pizzas)
            {
                viewModelPizzas.Add(
                    new PizzaViewModel
                    {
                        Id = item.Id,
                        Image = item.Image,
                        Name = item.Name,
                        Price = item.Price,
                        Size = item.Size
                    });
            }

            return View(viewModelPizzas);
        }
    }
}
