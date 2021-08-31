using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Services;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            // Domain Model bussiness layer call
            List<User> allUsers = _userService.GetAllUsers();

            List<UserViewModel> viewUsers = new List<UserViewModel>();

            // Mapping section Model to ViewModel
            foreach (User user in allUsers)
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userService.AddNewUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            User user = _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _userService.UpdateExistingUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            User user = _userService.GetUserById(id);

            UserViewModel userViewModel = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Username = user.Username,
                Phone = user.Phone,
                Id = user.Id
            };

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUserById(id);
            return RedirectToAction("Index");
        }
    }
}
