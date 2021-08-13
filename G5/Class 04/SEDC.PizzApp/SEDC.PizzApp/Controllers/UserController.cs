using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzApp.Controllers
{
   public class UserController : Controller
   {
      [Route("User")]
      public IActionResult GetUser()
      {
         return View("User");
      }

      public IActionResult GetContact()
      {
         return RedirectToAction("Admin", "Admin");
      }

      [Route("Empty")]
      public IActionResult GetEmpty()
      {
         return new EmptyResult();
      }

      [Route("Id/{id}")]
      public IActionResult GetId(int id)
      {
         return View("Id");
      }
   }
}
