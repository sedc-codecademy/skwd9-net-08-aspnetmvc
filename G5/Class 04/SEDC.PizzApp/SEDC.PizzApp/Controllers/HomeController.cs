using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzApp.Models;
using System.Diagnostics;

namespace SEDC.PizzApp.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         var person = new User
         {
            FirstName = "Bojan",
            LastName = "Zdravkovski",
            Address = "Ilindenska",
            Phone = 123123123
         };

         var order = new Order
         {
            Id = 15,
            User = person,
            Pizza = "4 sezoni",
            Price = 300
         };

         // Using ViewData dictionary
         ViewData.Add("Title", "Home page ViewData");
         ViewData.Add("Order", order);

         ViewData["asd"] = "asd";

         // Using ViewBag 
         ViewBag.Title = "Home page ViewBag";
         ViewBag.Order = order;

         // Mapping data from domain model to view model
         var orderDetailsViewModel = new OrderDetailsViewModel
         { 
            Address = person.Address,
            FirstName = person.FirstName,
            LastName = person.LastName,
            FullName = person.GetFullName(),
            Contact = person.Phone,
            Id = order.Id,
            Pizza = order.Pizza,
            Price = order.Price
         };

         return View(orderDetailsViewModel);
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
