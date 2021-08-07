using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzApp.Controllers
{
   //[Route("Custom/[Action]")]
   public class OrderController : Controller
   {
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

      // Custom route with action name

   }
}
