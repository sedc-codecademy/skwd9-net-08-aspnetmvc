using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.DI;
using SEDC.PizzApp.Models;

namespace SEDC.PizzApp.Controllers
{
   public class UserController : Controller
   {
      #region EXAMPLES

      //[Route("User")]
      //public IActionResult GetUser()
      //{
      //   return View("User");
      //}

      //public IActionResult GetContact()
      //{
      //   return RedirectToAction("Admin", "Admin");
      //}

      //[Route("Empty")]
      //public IActionResult GetEmpty()
      //{
      //   return new EmptyResult();
      //}

      //[Route("Id/{id}")]
      //public IActionResult GetId(int id)
      //{
      //   return View("Id");
      //}

      //public string GetPositionString(Position position)
      //{
      //   return position.ToString();
      //}

      #endregion

      private IUserService _userService;

      public UserController(IUserService userService)
      {
         _userService = userService;
      }

      public UserController()
      {
         _userService = new UserService();
      }

      [HttpGet]
      public IActionResult Register()
      {
         var users = _userService.GetAllUsers();

         return View();
      }

      [HttpPost]
      public IActionResult Register(UserRegisterViewModel userRegister)
      {
         // USERREGISTER OBJEKTOT SE KORISTI ZA PONATAMOSNO
         // ZACUVUVANJE VO BAZA

         var user = new User
         {
            FirstName = userRegister.FirstName,
            LastName = userRegister.LastName,
            Address = userRegister.Address
         };

         // Db.Save(user);

         return RedirectToAction("Index", "Home");
      }
   }
}
