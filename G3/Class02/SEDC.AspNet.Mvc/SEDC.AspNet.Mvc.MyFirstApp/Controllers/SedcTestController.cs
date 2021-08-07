using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.MyFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.MyFirstApp.Controllers
{
    //[Route("[controller]/[action]")] // default route
    [Route("sedc")]
    public class SedcTestController : Controller
    {
        //[Route("index")]
        [HttpGet("test")]
        public IActionResult Index(int id)
        {
            //HTTP verbs GET,POST,PUT,DELETE,PATCH,OPTION

            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View("TestView");
        }
        
        [HttpGet]
        public string SayHello()
        {
            return "Hello SEDC";
        }
        
        [HttpGet]
        public IActionResult Redirecting()
        {
            //return RedirectToAction("About");
            return RedirectToAction(nameof(About));
        }

        [HttpGet]
        public IActionResult HomeRedirect()
        {
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return Json(new
            {
                Name = "Trajan",
                LastName = "Stevkovski"
            });
        }

        [HttpGet("read-post/{id:int}")]
        public IActionResult ReadPostById(int id)
        {
            return Json(new
            {
                Id = id,
                Name = "SEDC"
            });
        }

        //[HttpGet("read-post/{name:alpha:minlength(6)}")] // with constraint
        [HttpGet("read-post/{name:alpha}")]
        public IActionResult ReadPostByName(string name)
        {
            return Json(new
            {
                Id = 1,
                Name = name
            });
        }

        [HttpGet("create-post")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost("create-post")]
        public IActionResult CreatePost(TestModel request)
        {
            return Json(request);
        }
    }
}
