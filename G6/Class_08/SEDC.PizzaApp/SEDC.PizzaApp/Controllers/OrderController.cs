using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order(int? pizzas)
        {
            OrderViewModel viewModel = new OrderViewModel();

            for (int i = 0; i < pizzas.GetValueOrDefault(); i++)
            {
                viewModel.Pizzas.Add(new PizzaViewModel());
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel viewModel)
        {
            Order order = new Order();
            return RedirectToAction("Index", "Home");
        }
    }
}
