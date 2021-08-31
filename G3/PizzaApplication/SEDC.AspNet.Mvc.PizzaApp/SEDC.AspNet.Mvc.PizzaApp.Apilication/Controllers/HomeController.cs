using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.AspNet.Mvc.PizzaApp.Apilication.Models;
using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;

namespace SEDC.AspNet.Mvc.PizzaApp.Apilication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaService _pizzaService;

        public HomeController(ILogger<HomeController> logger,
            IPizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var response = _pizzaService.GetMenu();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
