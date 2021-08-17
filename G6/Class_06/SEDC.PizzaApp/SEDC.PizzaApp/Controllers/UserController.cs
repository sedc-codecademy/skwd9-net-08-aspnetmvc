using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult Index()
        {
            // Domain Model bussiness layer call
            List<User> allUsers = _userService.GetAllUsers();

            List<UserViewModel> viewUsers = new List<UserViewModel>();

            // Mapping section Model to ViewModel
            foreach(User user in allUsers)
            {
                UserViewModel mappedUser = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Phone = user.Phone,
                    Username = user.Username
                };

                viewUsers.Add(mappedUser);
            }

            return View(viewUsers);
        }

        public IActionResult Details(int id)
        {
            // Domain Model bussiness layer call
            User user = _userService.GetUserById(id);

            // Mapping section Model to ViewModel
            UserViewModel viewUser = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Phone = user.Phone,
                Username = user.Username
            };

            return View(viewUser);
        }
    }
}
