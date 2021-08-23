using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.Models;

namespace SEDC.PizzApp.Controllers
{
   //[Route("Custom/[Action]")]
   public class OrderController : Controller
   {
      [HttpGet]
      public IActionResult NewOrder()
      {
         var newOrder = new NewOrderViewModel();

         return View(newOrder);
      }

      [HttpPost]
      public IActionResult NewOrder(NewOrderViewModel newOrderViewModel)
      {
         return RedirectToAction("Index", "Home");
      }

      [Route("/OrderDetails/{id}")]
      public IActionResult GetOrderDetails(int? id)
      {
         var person = new User
         {
            Address = "Ilindenska",
            FirstName = "Bojan",
            LastName = "Zdravkovski",
            Phone = 123123123
         };

         var order = new Order
         {
            Id = id,
            Pizza = "Kapricioza",
            Price = 300,
            Size = Enums.Size.Large,
            User = person,
            Delivered = true
         };

         return View("OrderDetails", order);
      }

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

      public IActionResult Helpers()
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
            Delivered = false,
            Size = Enums.Size.Small
         };

         return View(order);
      }
   }
}
