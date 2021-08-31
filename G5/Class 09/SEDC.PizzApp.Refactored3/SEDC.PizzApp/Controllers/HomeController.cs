using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzApp.Models;
using System.Diagnostics;
using SEDC.PizzApp.Domain.Models;
using SEDC.PizzApp.Refactored.Models;
using SEDC.PizzApp.Services.Services;

namespace SEDC.PizzApp.Controllers
{
   public class HomeController : Controller
   {
      private IPizzaOrderService _pizzaOrderService;
      private IUserService _userService;

      public HomeController(IPizzaOrderService pizzaOrderService, IUserService userService)
      {
         _pizzaOrderService = pizzaOrderService;
         _userService = userService;
      }

      public IActionResult Index()
      {
         return View(new HomeViewModel());
      }

      [HttpPost]
      public IActionResult Index(HomeViewModel homeViewModel)
      {
         return RedirectToAction("Order", "Order", 
            new { pizzas = homeViewModel.NumberOfPizzas });
      }

      public IActionResult Contact()
      {
         return View();
      }

      public IActionResult About()
      {
         return View();
      }

      [HttpPost]
      public IActionResult Feedback(FeedbackViewModel feedbackViewModel)
      {
         var feedback = new Feedback
         {
            Email = feedbackViewModel.Email,
            Message = feedbackViewModel.Message,
            Name = feedbackViewModel.Name
         };

         _userService.GiveFeedback(feedback);

         return RedirectToAction("Index");
      }

      public IActionResult Menu()
      {
         var menu = _pizzaOrderService.GetMenu();
         var pizzaViewModels = new List<PizzaViewModel>();

         foreach (var pizza in menu)
         {
            pizzaViewModels.Add(new PizzaViewModel
            {
               Id = pizza.Id,
               Image = pizza.Image,
               PizzaName = pizza.Name,
               Price = pizza.Price,
               Size = pizza.Size
            });
         }

         var menuViewModel = new MenuViewModel
         {
            Menu = pizzaViewModels
         };

         return View(menuViewModel);
      }
   }
}
