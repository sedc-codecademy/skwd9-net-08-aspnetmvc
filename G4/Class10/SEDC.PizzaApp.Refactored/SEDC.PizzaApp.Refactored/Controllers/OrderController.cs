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

        public OrderController(IOrderService orderService, IMenuService menuService)
        {
            _orderService = orderService;
            _menuService = menuService;
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
                    PizzaCount = order.PizzaOrders.Count,
                    User = $"{order.User.FirstName} {order.User.LastName}"
                });
            }

            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Order(int numberOfPizzas)
        {
            var order = new OrderViewModel();
            order.Pizzas = new List<PizzaViewModel>();
            for(int i = 0; i < numberOfPizzas; i++)
            {
                order.Pizzas.Add(new PizzaViewModel());
            }

            order.AvailablePizzas = _menuService.GetPizzasInMenu();

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
                order.PizzaOrders = new List<PizzaOrder>();
                foreach(PizzaViewModel pizzaViewModel in model.Pizzas)
                {
                    Pizza pizza = _menuService.GetPizzaFromMenu(pizzaViewModel.Name, pizzaViewModel.Size);
                    PizzaOrder pizzaOrder = new PizzaOrder()
                    {
                        Pizza = pizza,
                        PizzaId = pizza.Id
                    };
                    order.PizzaOrders.Add(pizzaOrder);
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

        [HttpGet("order/edit/{id}")]
        public IActionResult OrderEdit(int id)
        
         {
            
            Order order = _orderService.GetOrderById(id);
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                OrderId = order.OrderId,
                DeliveryPrice = order.DeliveryPrice,
                IsDelivered = order.IsDelivered,
                UserId = order.User.Id,
                FirstName = order.User.FirstName,
                LastName = order.User.LastName,
                Address = order.User.Address,
                Phone = order.User.Phone
            };

            orderViewModel.Pizzas = new List<PizzaViewModel>();
            foreach(var pizzaOrder in order.PizzaOrders)
            {
                orderViewModel.Pizzas.Add(new PizzaViewModel()
                {
                    Id = pizzaOrder.Pizza.Id,
                    Name = pizzaOrder.Pizza.Name,
                    Price = pizzaOrder.Pizza.Price,
                    Size = pizzaOrder.Pizza.Size
                });
            }

            orderViewModel.AvailablePizzas = _menuService.GetPizzasInMenu();

            return View(orderViewModel);
        }

        [HttpPost("order/edit/{id}")]
        public IActionResult OrderEdit(OrderViewModel model)
        {
            var order = new Order()
            {
                IsDelivered = model.IsDelivered,
                DeliveryPrice = model.DeliveryPrice,
                OrderId = model.OrderId
            };

            order.User = new User()
            {
                Id = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Phone = model.Phone
            };

            order.PizzaOrders = new List<PizzaOrder>();
            foreach (PizzaViewModel pizzaViewModel in model.Pizzas)
            {
                Pizza pizza = _menuService.GetPizzaFromMenu(pizzaViewModel.Name, pizzaViewModel.Size);
                PizzaOrder pizzaOrder = new PizzaOrder()
                {
                    Pizza = pizza,
                    PizzaId = pizza.Id
                };
                order.PizzaOrders.Add(pizzaOrder);
            }
            _orderService.UpdateExistingOrder(order);
            return View("_ThankYou");
        }

        public IActionResult OrderDelete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index", "Order");
        }

        [HttpGet("orderdetails/{id}")]
        public IActionResult OrderDetails(int id)
        {
            var order = _orderService.GetOrderById(id);

            var orderDetailsViewModel = new OrderDetailsViewModel()
            {
                OrderId = order.OrderId,
                User = $"{order.User.FirstName} {order.User.LastName}",
                Pizza = order.PizzaOrders[0].Pizza.Name,
                DeliveryPrice = order.DeliveryPrice
            };

            return View(orderDetailsViewModel);
        }
    }
}
