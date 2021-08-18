using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Services.Implementation;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderService.GetAll();

            var orderItems = new List<OrderItemViewModel>();

            foreach(var order in orders)
            {
                orderItems.Add(new OrderItemViewModel()
                {
                    OrderId = order.OrderId,
                    Pizza = order.Pizza,
                    User = order.User
                });
            }

            return View(orderItems);
        }

        [HttpGet("orderdetails/{id}")]
        public IActionResult OrderDetails(int id)
        {
            var order = _orderService.GetOrderById(id);

            var orderDetailsViewModel = new OrderDetailsViewModel()
            {
                OrderId = order.OrderId,
                User = order.User,
                Pizza = order.Pizza,
                DeliveryPrice = order.DeliveryPrice
            };

            return View(orderDetailsViewModel);
        }
    }
}
