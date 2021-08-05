using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.MyFirstApp.Controllers
{
    public class SedcTestController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult About()
        {
            return View("TestView");
        }

        public string SayHello()
        {
            return "Hello SEDC";
        }

        public IActionResult Redirecting()
        {
            //return RedirectToAction("About");
            return RedirectToAction(nameof(About));
        }

        public IActionResult HomeRedirect()
        {
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult GetData()
        {
            return Json(new
            {
                Name = "Trajan",
                LastName = "Stevkovski"
            });
        }

        public IActionResult ReadPostById(int id)
        {
            return Json(new
            {
                Id = id,
                Name = "SEDC"
            });
        }

        public IActionResult ReadPostByName(string name)
        {
            return Json(new
            {
                Id = 1,
                Name = name
            });
        }
    }
}
