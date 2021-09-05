using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using SEDC.AspNet.Mvc.PizzaApp.Models.ServiceResponse;
using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Pizza> _pizzaRepository;
        private const string _currency = "C2";

        public PizzaOrderService(IRepository<Order> orderRepository,
            IRepository<User> userRepository,
            IRepository<Pizza> pizzaRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public OrderVM GetOrders()
        {
            var orders = _orderRepository.GetAll();

            var mappedOrders = orders.Select(x =>
                    new OrderItemVM
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Price = x.Price,
                        Pizzas = x.PizzaOrders.Select(p => PizzaVM.Map(p.Pizza))
                    });

            var response = new OrderVM
            {
                Currency = _currency,
                Orders = mappedOrders,
                LastPizza = GetLastPizzaName(),
                MostPopularPizza = GetMostPopularPizza(),
                NameOfFirstCustomer = _userRepository.GetAll().LastOrDefault()?.FirstName ?? string.Empty,
                OrderCount = orders.Count
            };

            return response;
        }

        public CreateOrderServiceResponse CreateOrder(CreateOrderVM request)
        {
            var pizza = _pizzaRepository
                .GetByFilter(x => x.Name.Equals(request.PizzaName, System.StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if(pizza == null)
            {
                return new CreateOrderServiceResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Please enter valid pizza name!",
                    Order = request
                };
            }

            var user = _userRepository
                .GetByFilter(x => x.FirstName.Equals(request.FirstName, System.StringComparison.InvariantCultureIgnoreCase) &&
                    x.LastName.Equals(request.LastName, System.StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            User userModel = new User();
            if(user != null)
            {
                userModel = user;
            }
            else
            {
                userModel = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    Phone = request.Phone
                };
            }

            var pizzaModel = new PizzaOrder
            {
                Pizza = pizza
            };

            var order = new Order
            {
                User = userModel,
                PizzaOrders = new List<PizzaOrder> { pizzaModel }
            };

            _orderRepository.Insert(order);

            return new CreateOrderServiceResponse
            {
                IsSuccess = true
            };
        }

        private string GetLastPizzaName()
        {
            // get last order
            var lastOrder = _orderRepository.GetAll().LastOrDefault();
            
            if(lastOrder != null)
            {
                var lastPizzaOrder = lastOrder.PizzaOrders.LastOrDefault();
                if(lastPizzaOrder != null)
                {
                    return lastPizzaOrder.Pizza.Name;
                }
            }

            return string.Empty;

            // return lastOrder?.PizzaOrders?.LastOrDefault()?.Pizza.Name ?? string.Empty;
        }

        private string GetMostPopularPizza()
        {
            return _orderRepository
                .GetAll()
                .SelectMany(x => x.PizzaOrders) // Flattening (All pizzas from all orders)
                .GroupBy(x => x.Pizza.Name) // We group them by name (2 peperoni, 3 kapri ...)
                .OrderByDescending(x => x.Count()) // Order by desc so we get the first pizza that is most ordered
                .FirstOrDefault() // takes the first group (3 kapri pizzas) (Kapri, List<PizzaOrder>)
                .Select(x => x.Pizza.Name) // selects only the names
                .FirstOrDefault(); //gets the first name
        }
    }
}
