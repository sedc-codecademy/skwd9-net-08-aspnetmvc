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
        [Route("")]
        //[Route("/")]
        //[Route("index")]
        //[Route("orderindex")]
        public IActionResult Index()
        {
            //User person = new User()
            //{
            //    FirstName = "Martin",
            //    LastName = "Jankuloski",
            //    Address = "Street 01",
            //    Phone = 38977123456
            //};
            //Order order = new Order()
            //{
            //    Id = 1,
            //    Pizza = new Pizza
            //    {
            //        Name = "Pepperoni",
            //        Price = 350
            //    },
            //    User = person,
            //    IsDelivered = true
            //};

            // Example using ViewData to pass data to View
            //ViewData.Add("Title", "Order Home Page");
            //ViewData.Add("Order", order);

            // Example using ViewBag to pass data to View
            //ViewBag.Order = order;
            //ViewBag.Naracka = order;

            //var orderDetailsViewModel = new OrderDetailsViewModel()
            //{
            //    Id = order.Id,
            //    FullName = $"{person.FirstName} {person.LastName}",
            //    Address = person.Address,
            //    Contact = person.Phone.ToString(),
            //    Pizza = order.Pizza.Name,
            //    Price = order.Pizza.Price,
            //    IsDelivered = order.IsDelivered,
            //    Status = order.IsDelivered ? "Order has been delivered!" : "Not yet delivered!"
            //};

            //var ordersList = new List<OrderDetailsViewModel> { orderDetailsViewModel
            //new OrderDetailsViewModel
            //{
            //    Id = 10,
            //    FullName = "Person 2",
            //    Address = "Address 2",
            //    Contact = "12356",
            //    Pizza = "Capri",
            //    Price = 100,
            //    IsDelivered = false,
            //    Status = "Not yet delivered!"
            //}
            //};

            ViewBag.Title = "Order Home Page";
            var orders = StaticDb.Orders;

            var masterOrdersList = new MasterOrderListViewModel()
            {
                DeliveredOrders = new List<OrderListViewModel>(),
                PendingOrders = new List<OrderListViewModel>()
            };

            //var ordersList = new List<OrderListViewModel>();

            foreach(var order in orders)
            {
                var orderListViewModel = new OrderListViewModel
                {
                    Id = order.Id,
                    FullName = $"{order.User.FirstName} {order.User.LastName}",
                    Price = order.Pizza.Price + order.DeliveryPrice
                };
                if (order.IsDelivered)
                {
                    masterOrdersList.DeliveredOrders.Add(orderListViewModel);
                    masterOrdersList.CountOfDeliveredOrders++;
                } else
                {
                    masterOrdersList.PendingOrders.Add(orderListViewModel);
                    masterOrdersList.CountOfPendingOrders++;
                }

                //ordersList.Add(new OrderListViewModel
                //{
                //    Id = order.Id,
                //    FullName = $"{order.User.FirstName} {order.User.LastName}",
                //    Price = order.Pizza.Price + order.DeliveryPrice,
                //    //IsDelivered = order.IsDelivered
                //});
            }

            return View(masterOrdersList);
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
