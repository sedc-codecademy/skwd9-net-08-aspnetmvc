using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.Class03.App.Database;
using SEDC.AspNet.Mvc.Class03.App.Models.DataAccessModels;
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

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.Title = "These is your order details ";
            var order = PizzaDatabase.Orders.FirstOrDefault(o => o.Id == id);

            if(order == null)
            {
                // redirect
                TempData["Error"] = $"Order with id {id} was not found!";
                return RedirectToAction("Index");
            }

            var user = PizzaDatabase.Users.FirstOrDefault(u => u.Id == order.UserId);
            var pizza = PizzaDatabase.Pizzas.FirstOrDefault(p => p.Id == order.PizzaId);
            var address = PizzaDatabase.Addresses.FirstOrDefault(x => x.Id == user.AddressId);

            var orderVm = new OrderVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = address.Name,
                Phone = user.Phone,
                PizzaName = pizza.Name,
                Size = pizza.Size,
                Delivered = order.Delivered
            };

            return View(orderVm);
        }

        [HttpGet("create")]
        public IActionResult Create(string error)
        {
            ViewBag.Error = error;
            return View(new CreateOrderVM());
        }

        [HttpPost("create")]
        public IActionResult Create(CreateOrderVM request)
        {
            var pizza = PizzaDatabase.Pizzas.FirstOrDefault(
                p => p.Name == request.PizzaName && p.Size == request.Size);

            if(pizza == null)
            {
                return RedirectToAction("Create", new { error = "There is no pizza like that in the menu" });
            }

            var user = new User
            {
                Id = PizzaDatabase.Users.Count + 1,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };

            var address = new Address
            {
                Id = PizzaDatabase.Addresses.Count + 1,
                Name = request.Address,
                UserId = user.Id
            };

            user.AddressId = address.Id;

            var order = new Order
            {
                Id = PizzaDatabase.Orders.Count + 1,
                Delivered = false,
                PizzaId = pizza.Id,
                UserId = user.Id
            };

            PizzaDatabase.Users.Add(user);
            PizzaDatabase.Addresses.Add(address);
            PizzaDatabase.Orders.Add(order);

            return RedirectToAction("Index");
        }
    }
}
