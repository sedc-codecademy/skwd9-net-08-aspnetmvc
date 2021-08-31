using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.CacheRepository;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private IRepository<Pizza> _pizzaRepository;
        private IRepository<Order> _orderRepository;

        #region Tightly coupled dependency
            //registering implementation for interface in constructor(without container)
            //public PizzaService()
            //{
            //    _pizzaRepository = new PizzaRepository();
            //}
        #endregion

        public PizzaOrderService(IRepository<Pizza> pizzaRepository, IRepository<Order> orderRepository)
        {
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            return orders;
        }

        public List<Pizza> GetMenu()
        {
            return _pizzaRepository.GetAll();
        }

        public Order GetLastOrder()
        {
            return _orderRepository.GetAll().LastOrDefault();
        }

        // TODO: Implement this method
        public string GetMostPopularPizza()
        {
            List<Order> orders = _orderRepository.GetAll();

            List<PizzaOrder> pizzas = orders
                                      .SelectMany(x => x.PizzaOrders)
                                      .ToList();

            string mostPopularPizza = pizzas
                .GroupBy(x => x.Pizza.Name)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault()
                .Select(x => x.Pizza.Name)
                .FirstOrDefault();

            return mostPopularPizza;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public int GetOrderCount()
        {
            return _orderRepository.GetAll().Count;
        }

        public void MakeNewOrder(Order order)
        {
            _orderRepository.Insert(order);
        }
    }
}
