using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private const string _currency = "C2";

        public PizzaOrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
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
                //MostPopularPizza
            };

            return null;
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

        //private string GetMostPopularPizza()
        //{

        //}
    }
}
