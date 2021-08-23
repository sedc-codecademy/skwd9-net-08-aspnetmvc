using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Enums;
using SEDC.PizzaApp.Web.Models.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //How to show only one order details
            //var pizzaMargarita = StaticDB.Pizzas.First();
            //User newUser = new User
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Address = "Partiznaska br.19",
            //    Phone = 111222333
            //};

            //Order order = new Order
            //{
            //    Pizza = pizzaMargarita,
            //    User = newUser,
            //    PaymentMethod = PaymentMethod.Cash,
            //    Price = pizzaMargarita.Price * 2
            //};

            //OrderDetailsViewModel orderDetails = new OrderDetailsViewModel
            //{
            //    Id = order.Id,
            //    PaymentMethod = order.PaymentMethod,
            //    PizzaName = pizzaMargarita.Name,
            //    UserFullName = $"{order.User.FirstName} {order.User.LastName}",
            //    Price = order.Price
            //};

            List<Order> orders = StaticDB.Orders;
            List<OrderDetailsViewModel> orderDetails = new List<OrderDetailsViewModel>();

            foreach (Order order in orders)
            {
                orderDetails.Add(OrderMapper.OrderToOrderDetailsViewModel(order));
            }

            return View(orderDetails);
        }

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            if (id > 0)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
                if (orderDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedModel = OrderMapper.OrderToOrderDetailsViewModel(orderDetails);
                ViewData.Add("OrderDetails", mappedModel);

                return View(mappedModel);
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            if (id > 0)
            {
                var order = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
                if (order == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedOrder = OrderMapper.OrderToOrderDetailsViewModel(order);

                return View(mappedOrder);
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult DeleteOrderPost(int? id)
        {
            if (id != null)
            {
                var order = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
                if (order == null)
                {
                    return View("ResourceNotFound");
                }

                //StaticDB.Orders.Remove(order);
                StaticDB.Orders.RemoveAt(order.Id);

                return RedirectToAction("Index");
            }
            return View("Error");
        }

        //[HttpPost]
        //public IActionResult DeleteOrderPost(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult DeleteOrder(OrderDetailsViewModel order)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditOrder(int? id)
        {
            if (id != null)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);

                if (orderDetails == null)
                {
                    return View("ResourceNotFound");
                }

                var mappedOrder = OrderMapper.OrderToOrderViewModel(orderDetails);

                //Sending users from controller
                ViewBag.Users = StaticDB.Users.Select(user => UserMapper.UserToUserViewModel(user));// linq expressions//mapping with one line
               
                //Sending select list from the controller
                var usersForDropdown = StaticDB.Users.Select(user => UserMapper.UserToUserViewModel(user));
                ViewBag.Users1 = new SelectList(usersForDropdown, "Id", "FullName");
                
                //mapped users with list, mapping with foreach
                List<UserViewModel> mappedUsers = new List<UserViewModel>();
                var users = StaticDB.Users;

                foreach (var item in users)
                {
                    mappedUsers.Add(UserMapper.UserToUserViewModel(item));
                }
                return View(mappedOrder);
            }
            return View("Error");
        }
    }
}
