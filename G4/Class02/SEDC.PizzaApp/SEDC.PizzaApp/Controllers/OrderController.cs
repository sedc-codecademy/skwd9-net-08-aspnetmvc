using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    // Controller access point
    [Route("pizza")]

    // Controller/ActionName attribute route
    //[Route("Pizza/[Action]")]
    public class OrderController : Controller
    {
        Dictionary<int, string> lookUp;

        public OrderController()
        {
            lookUp = new Dictionary<int, string>();
            lookUp.Add(10, "ViewWithDifferentName");
        }

        [Route("{id}")]
        public IActionResult Index(int id)
        {
            if(lookUp.ContainsKey(id))
                return RedirectToAction(lookUp[id]);
            return View();
        }


        // accessed by pizza/different/view
        [HttpGet]
        [Route("different/view")]
        public IActionResult ViewWithDifferentName()
        {
            return View("Index");
        }

        // accessed by /pizza
        [Route("")]
        public IActionResult Alert()
        {
            return new EmptyResult();
        }

        // accessed by /pizza/order or pizza/order/10 (or any int number)
        [Route("order")]
        public IActionResult Order(int? id)
        {
            if (id.HasValue)
                return View();
            return RedirectToAction("ViewWithDifferentName");
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Route("data")]
        public IActionResult OrderData()
        {
            var order = new { Id = 12, IsDelivered = false };
            return new JsonResult(order);
        }
    }
}
