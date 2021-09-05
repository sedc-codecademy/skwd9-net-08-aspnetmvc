using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using SEDC.PizzaApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IPizzaOrderService _pizzaService;
        private IUserService _userService;

        public OrderController(IPizzaOrderService pizzaService, IUserService userService)
        {
            _pizzaService = pizzaService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<Order> orders = _pizzaService.GetAllOrders();

            // This is the right way of fetching data. Instead of using DOMAIN model in the controller
            // we need to use DTO model

            // List<OrderDTO> orders = _pizzaService.GetAllOrders();

            // Mapping section

            List<OrderItemViewModel> viewOrders = new List<OrderItemViewModel>();

            foreach (var order in orders)
            {
                List<PizzaViewModel> pizzasViewModel = new List<PizzaViewModel>();
                foreach (var pizzaOrder in order.PizzaOrders)
                {
                    pizzasViewModel.Add(new PizzaViewModel
                    {
                        Id = pizzaOrder.Pizza.Id,
                        Image = pizzaOrder.Pizza.Image,
                        Name = pizzaOrder.Pizza.Name,
                        Price = pizzaOrder.Pizza.Price,
                        PizzaSize = pizzaOrder.Pizza.PizzaSize
                    });
                }
                viewOrders.Add(new OrderItemViewModel
                {
                    Id = order.Id,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Price = order.Price,
                    Pizzas = pizzasViewModel
                });
            }


            OrdersViewModel model = new OrdersViewModel()
            {
                OrdersCount = _pizzaService.GetOrderCount(),
                MostPopularPizza = _pizzaService.GetMostPopularPizza(),
                NameOfFirstCustomer = _userService.GetLastUserName(),
                LastOrderedPizza = _pizzaService.GetLastOrder()?.PizzaOrders.FirstOrDefault()?.Pizza?.Name,
                Orders = viewOrders
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Order(int pizzas)
        {
            OrderViewModel viewModel = new OrderViewModel();

            viewModel.Pizzas = new List<PizzaViewModel>();

            for (int i = 0; i < pizzas; i++)
            {
                viewModel.Pizzas.Add(new PizzaViewModel());
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order();
                List<PizzaOrder> pizzas = new List<PizzaOrder>();

                foreach (PizzaViewModel pizza in model.Pizzas)
                {

                    var pizzaModel = _pizzaService.GetPizzaFromMenu(pizza.Name, pizza.PizzaSize);
                    PizzaOrder pizzaOrder = new PizzaOrder
                    {
                        //adding object to property when trying to create new object
                        //Pizza = _pizzaService.GetPizzaFromMenu(pizza.Name, pizza.PizzaSize),
                        Order = order
                    };
                    pizzaOrder.PizzaId = pizzaModel.Id;
                    pizzas.Add(pizzaOrder);
                }
                order.PizzaOrders = pizzas;

                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone
                };
                order.User = user;

                _pizzaService.MakeNewOrder(order);

                return RedirectToAction("Index", "Order");
            }
            else
            {
                return View("Order", model);
            }

        }
    }
}
