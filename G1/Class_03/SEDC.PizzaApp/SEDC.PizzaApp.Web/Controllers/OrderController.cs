using Microsoft.AspNetCore.Mvc;
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
    }
}
