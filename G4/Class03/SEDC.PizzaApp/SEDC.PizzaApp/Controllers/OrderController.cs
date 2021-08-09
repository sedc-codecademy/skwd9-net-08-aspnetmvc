using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    // Controller Route Attribute 
    //[Route("naracka")]

    // Controller Route Attribute with Action Name
    //[Route("naracka/[Action]")]
    public class OrderController : Controller
    {
        //[Route("")]
        //[Route("/")]
        //[Route("index")]
        public IActionResult Index()
        {
            User person = new User()
            {
                FirstName = "Martin",
                LastName = "Jankuloski",
                Address = "Street 01",
                Phone = 38977123456
            };
            Order order = new Order()
            {
                Id = 1,
                Pizza = "Pepperoni",
                Price = 350,
                User = person
            };

            // Example using ViewData to pass data to View
            //ViewData.Add("Title", "Order Home Page");
            //ViewData.Add("Order", order);

            // Example using ViewBag to pass data to View
            //ViewBag.Title = "Order Home Page";
            //ViewBag.Order = order;
            //ViewBag.Naracka = order;

            var orderDetailsViewModel = new OrderDetailsViewModel()
            {
                Id = order.Id,
                FullName = $"{person.FirstName} {person.LastName}",
                Address = person.Address,
                Contact = person.Phone.ToString(),
                Pizza = order.Pizza,
                Price = order.Price
            };

            return View(orderDetailsViewModel);
        }

        //[Route("different")]
        public IActionResult ViewWithDifferentName()
        {
            // this will return Views/Order/Index.cshtml view
            //return View("Index");

            // this will return Views/Order/Secondary.cshtml view
            return View("Secondary");
        }

        //[Route("empty")]
        public IActionResult Nothing()
        {
            return new EmptyResult();
        }

        //[Route("order/{id?}")]
        public IActionResult Order(int? id)
        {
            if (id.HasValue)
                return View(); // this goes to Views/Order/Order.cshtml view (default)

            return RedirectToAction("Index", "Order"); // this invokes Index action from OrderController
        }

        //[Route("json")]
        public IActionResult OrderData()
        {
            var order = new { Id = 11234, IsDelivered = false };
            return new JsonResult(order); // return type => JsonResult
        }

        //[Route("contact")]
        //[Route("kontakt")]
        //[Route("контакт")]
        //[Route("contact/information")]
        public IActionResult ContactInfo()
        {
            return View();
        }
    }
}
