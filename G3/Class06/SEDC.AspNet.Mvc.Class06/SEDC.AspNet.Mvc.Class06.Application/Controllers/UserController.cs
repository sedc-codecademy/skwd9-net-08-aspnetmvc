using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class06.Application.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            //_userService = new UserService(new UserRepository());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var response = _userService.GetUser(id);
            return Json(response);
        }
    }
}
