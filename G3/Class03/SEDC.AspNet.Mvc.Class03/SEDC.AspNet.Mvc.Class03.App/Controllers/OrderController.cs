using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.Class03.App.Database;
using SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels;
using SEDC.AspNet.Mvc.Class03.App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Class03.App.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData.Add("Title", "Welcome to the Orders page!");

            // pizza name
            // number of orders
            // full name
            // orders

            var orders = PizzaDatabase.Orders;
            var firstOrder = orders.FirstOrDefault();
            var user = PizzaDatabase.Users.FirstOrDefault(u => u.Id == firstOrder.UserId);

            var firstPizza = PizzaDatabase.Pizzas.FirstOrDefault(p => p.Id == firstOrder.PizzaId);

            var orderListVM = new OrderListVM
            {
                FirstCustomerName = $"{user.FirstName} {user.LastName}",
                FirstPizza = firstPizza.Name,
                NumberOfOrders = orders.Count
            };

            List<OrderDto> listOfOrders = new List<OrderDto>();
            foreach (var order in orders)
            {
                var pizza = PizzaDatabase.Pizzas.FirstOrDefault(p => p.Id == order.PizzaId);

                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    Delivered = order.Delivered,
                    Price = pizza.Price,
                    Pizza = new PizzaDto
                    {
                        Name = pizza.Name,
                        Size = pizza.Size
                    }
                };

                listOfOrders.Add(orderDto);
            }

            orderListVM.Orders = listOfOrders;

            return View(orderListVM);
        }
    }
}
