using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Services.Implementation;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();

            var userItems = new List<UserItemViewModel>();

            foreach(var user in users)
            {
                userItems.Add(new UserItemViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }

            return View(userItems);
        }
    }
}
