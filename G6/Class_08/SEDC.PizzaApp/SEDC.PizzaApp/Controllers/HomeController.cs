using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Services;
using System.Diagnostics;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPizzaService _pizzaService;

        public HomeController(ILogger<HomeController> logger, IPizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pizza(int id)
        {
            var pizza = _pizzaService.GetPizzaById(id);
            return new JsonResult(pizza);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
