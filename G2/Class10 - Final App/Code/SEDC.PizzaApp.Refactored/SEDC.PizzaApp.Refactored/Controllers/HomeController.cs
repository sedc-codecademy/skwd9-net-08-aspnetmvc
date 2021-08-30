using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.HomeViewModels;
using System.Diagnostics;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaService _pizzaService;
        private IOrderService _orderService;

        public HomeController(IPizzaService pizzaService, IOrderService orderService)
        {
            _pizzaService = pizzaService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.PizzaOnPromotion = _pizzaService.GetPizzaOnPromotion();
            homeIndexViewModel.OrderCount = _orderService.GetAllOrders().Count;
            return View(homeIndexViewModel);
        }

        public IActionResult Privacy()
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
