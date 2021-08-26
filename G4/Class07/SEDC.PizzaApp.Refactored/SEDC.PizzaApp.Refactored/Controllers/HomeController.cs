using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Services.Implementation;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _menuService = new MenuService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var menu = _menuService.GetMenu();
            var menuViewModel = new MenuViewModel();
            menuViewModel.Menu = new List<PizzaViewModel>();
            
            // mapping
            foreach(var pizza in menu)
            {
                menuViewModel.Menu.Add(new PizzaViewModel()
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Size = pizza.Size,
                    Price = pizza.Price
                });
            }

            return View(menuViewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
