using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.Models;

namespace SEDC.PizzApp.Controllers
{
   //[Route("Custom/[Action]")]
   public class OrderController : Controller
   {
      public IActionResult RazorOrder()
      {
         var person = new User
         {
            Address = "Adresa",
            FirstName = "John",
            LastName = "Doe",
            Phone = 123123123
         };

         var order = new Order
         {
            Id = 10,
            Pizza = "Kapriciosa",
            Price = 300,
            User = person,
            Delivered = false
         };

         return View(order);
      }

      public IActionResult Index()
      {
         return View();
      }

      // ViewResult
      public IActionResult Order()
      {
         return View("Order2");
      }

      // EmptyResult
      public IActionResult Empty()
      {
         return new EmptyResult();
      }

      // RedirectResult
      public IActionResult Order2(int? id)
      {
         if (id.HasValue)
         {
            return View();
         }

         return RedirectToAction("Order");
      }

      // RedirectResult in another controller
      [Route("Order/GetOrder/{id}")]
      public IActionResult Order3(int id)
      {
         return RedirectToAction("Privacy", "Home");
      }

      // JsonResult
      public IActionResult JsonResult()
      {
         var json = new { Id = 2, Name = "JSON" };

         return new JsonResult(json);
      }

      // CUSTOM ROUTE
      [HttpGet("Get/All/Users")]
      public IActionResult GetAllUsersFromUserIdAndSetupId(int? userId)
      {
         return View("Order2");
      }
   }
}
