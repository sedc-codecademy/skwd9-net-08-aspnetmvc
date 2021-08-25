using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
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
        private readonly IMenuService _menuService;

        public OrderController()
        {
            _orderService = new OrderService();
            _menuService = new MenuService();
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
                    //Pizza = order.Pizza.Name,
                    PizzaCount = order.Pizzas.Count,
                    User = $"{order.User.FirstName} {order.User.LastName}"
                });
            }

            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Order(int numberOfPizzas)
        {
            var order = new OrderViewModel();
            //order.Pizza = new PizzaViewModel();
            order.Pizzas = new List<PizzaViewModel>();
            for(int i = 0; i < numberOfPizzas; i++)
            {
                order.Pizzas.Add(new PizzaViewModel());
            }
            return View(order);
        }
        
        [HttpPost]
        public IActionResult Order(OrderViewModel model)
        {
            try
            {
                var order = new Order()
                {
                    IsDelivered = false,
                    DeliveryPrice = 0
                };

                order.User = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone
                };

                //order.Pizza = _menuService.GetPizzaFromMenu(model.Pizza.Name, model.Pizza.Size);
                order.Pizzas = new List<Pizza>();
                foreach(PizzaViewModel pizzaViewModel in model.Pizzas)
                {
                    Pizza pizza = _menuService.GetPizzaFromMenu(pizzaViewModel.Name, pizzaViewModel.Size);
                    order.Pizzas.Add(pizza);
                }

                _orderService.MakeNewOrder(order);

                return View("_ThankYou");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Something went wrong with saving this Order. Please try again";
                return View(model);
            }
        }

        [HttpGet("orderdetails/{id}")]
        public IActionResult OrderDetails(int id)
        {
            var order = _orderService.GetOrderById(id);

            var orderDetailsViewModel = new OrderDetailsViewModel()
            {
                OrderId = order.OrderId,
                User = $"{order.User.FirstName} {order.User.LastName}",
                Pizza = order.Pizzas[0].Name,
                DeliveryPrice = order.DeliveryPrice
            };

            return View(orderDetailsViewModel);
        }
    }
}
