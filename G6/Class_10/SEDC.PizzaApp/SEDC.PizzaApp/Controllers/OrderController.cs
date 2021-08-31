using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        private IUserService _userService;
        private IPizzaService _pizzaService;
        private IPizzaOrderService _pizzaOrderService;

        public OrderController(
            IUserService userService,
            IPizzaService pizzaService,
            IPizzaOrderService pizzaOrderService)
        {
            _userService = userService;
            _pizzaService = pizzaService;
            _pizzaOrderService = pizzaOrderService;
        }

        public IActionResult Index()
        {
            List<Order> orders = _pizzaOrderService.GetAllOrders();

            List<OrderViewModel> viewOrders = new List<OrderViewModel>();

            foreach (Order order in orders)
            {
                OrderViewModel orderViewModel = new OrderViewModel();

                orderViewModel.Username = order.User.Username;

                foreach (PizzaOrder pizzaOrder in order.PizzaOrders)
                {
                    PizzaViewModel pizzaViewModel = new PizzaViewModel
                    {
                        Id = pizzaOrder.Id,
                        Name = pizzaOrder.Pizza.Name,
                        Size = pizzaOrder.Pizza.Size,
                        Price = pizzaOrder.Pizza.Price
                    };

                    orderViewModel.Pizzas.Add(pizzaViewModel);
                }

                viewOrders.Add(orderViewModel);
            }

            double totalOrderPrice = 0;

            foreach (OrderViewModel orderViewModel in viewOrders)
            {
                totalOrderPrice = totalOrderPrice + orderViewModel.Pizzas.Select(x => x.Price).Sum();
            }

            ViewBag.TotalPriceOrders = totalOrderPrice;

            return View(viewOrders);
        }

        public IActionResult Order(int? pizzas)
        {
            OrderViewModel viewModel = new OrderViewModel();

            for (int i = 0; i < pizzas.GetValueOrDefault(); i++)
            {
                viewModel.Pizzas.Add(new PizzaViewModel());
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Order([FromForm] OrderViewModel viewModel)
        {
            User user = _userService.GetUserByUsername(viewModel.Username);
            List<Pizza> pizzaList = new List<Pizza>();

            foreach (PizzaViewModel item in viewModel.Pizzas)
            {
                Pizza pizza = _pizzaService.GetPizzaByNameAndSize(item.Name, item.Size);
                pizzaList.Add(pizza);
            }

            _pizzaOrderService.MakeNewOrder(user, pizzaList);
            return RedirectToAction("Index", "Home");
        }
    }
}
