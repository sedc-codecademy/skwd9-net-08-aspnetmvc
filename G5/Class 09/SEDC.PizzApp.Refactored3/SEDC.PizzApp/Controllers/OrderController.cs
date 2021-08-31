using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.Domain.Models;
using SEDC.PizzApp.Models;
using SEDC.PizzApp.Refactored.Models;
using SEDC.PizzApp.Services.Services;

namespace SEDC.PizzApp.Controllers
{
   public class OrderController : Controller
   {
      private IPizzaOrderService _pizzaOrderService;
      private IUserService _userService;

      public OrderController(IPizzaOrderService pizzaOrderService, IUserService userService)
      {
         _pizzaOrderService = pizzaOrderService;
         _userService = userService;
      }

      [Route("Orders")]
      public IActionResult Index()
      {
         // DOMAIN MODELS
         var orders = _pizzaOrderService.GetAllOrders();

         // VIEW MODELS
         var orderItemsViewModels = new List<OrderItemViewModel>();

         // MAPPING SECTION
         foreach (var order in orders)
         {
            var pizzaViewModels = new List<PizzaViewModel>();

            foreach (var pizzaOrder in order.PizzaOrders)
            {
               pizzaViewModels.Add(new PizzaViewModel
               {
                  Id = pizzaOrder.Pizza.Id,
                  Image = pizzaOrder.Pizza.Image,
                  PizzaName = pizzaOrder.Pizza.Name,
                  Price = pizzaOrder.Pizza.Price,
                  Size = pizzaOrder.Pizza.Size
               });
            }

            orderItemsViewModels.Add(new OrderItemViewModel
            {
               FirstName = order.User.FirstName,
               LastName = order.User.LastName,
               Id = order.Id,
               Price = order.Price,
               Pizzas = pizzaViewModels
            });
         }

         var ordersViewModel = new OrdersViewModel();

         ordersViewModel.LastPizza = _pizzaOrderService.GetLastOrder().PizzaOrders[0].Pizza.Name;
         ordersViewModel.MostPopularPizza = _pizzaOrderService.GetMostPopularPizza();
         ordersViewModel.NameOfFirstCustomer = _userService.GetLastUserName();
         ordersViewModel.OrderCount = _pizzaOrderService.GetOrderCount();
         ordersViewModel.Orders = orderItemsViewModels;

         // We send the mapped view model to the view
         return View(ordersViewModel);
      }

      [HttpGet("Order")]
      public IActionResult Order(string error, int? pizzas)
      {
         if ((error != null) || (pizzas == null))
         {
            return View("Error");
         }

         var orderViewModel = new OrderViewModel();

         for (int i = 0; i < pizzas.Value; i++)
         {
            orderViewModel.ChosenPizzas.Add(new PizzaViewModel());
         }

         return View(orderViewModel);
      }

      [HttpPost("Order")]
      public IActionResult Order(OrderViewModel orderViewModel)
      {
         var order = new Order();
         var pizzas = new List<PizzaOrder>();

         foreach (var pizzaViewModel in orderViewModel.ChosenPizzas)
         {
            var pizzaOrder = new PizzaOrder()
            {
               Pizza = _pizzaOrderService.GetPizzaFromMenu(
                  pizzaViewModel.PizzaName, pizzaViewModel.Size),
               Order = order
            };

            pizzaOrder.PizzaId = pizzaOrder.Pizza.Id;
            pizzas.Add(pizzaOrder);
         }

         var user = new User
         {
            Address = orderViewModel.Address,
            FirstName = orderViewModel.FirstName,
            LastName = orderViewModel.LastName,
            Phone = orderViewModel.Phone
         };

         order.PizzaOrders = pizzas;
         order.User = user;

         _pizzaOrderService.MakeNewOrder(order);

         return View("_ThankYou");
      }

      public IActionResult Details(int id)
      {
         var order = _pizzaOrderService.GetOrderById(id);

         if (order == null)
         {
            return View("Error");
         }

         var pizzas = new List<PizzaViewModel>();

         foreach (var pizzaOrder in order.PizzaOrders)
         {
            pizzas.Add(new PizzaViewModel
            {
               Image = pizzaOrder.Pizza.Image,
               PizzaName = pizzaOrder.Pizza.Name,
               Price = pizzaOrder.Pizza.Price,
               Size = pizzaOrder.Pizza.Size
            });
         }

         var orderDetailsViewModel = new OrderDetailsViewModel
         {
            Address = order.User.Address,
            Order = new OrderItemViewModel
            {
               Id = order.Id,
               FirstName = order.User.FirstName,
               Pizzas = pizzas,
               LastName = order.User.LastName,
               Price = order.Price
            },
            Phone = order.User.Phone
         };

         return View(orderDetailsViewModel);
      }
   }
}
