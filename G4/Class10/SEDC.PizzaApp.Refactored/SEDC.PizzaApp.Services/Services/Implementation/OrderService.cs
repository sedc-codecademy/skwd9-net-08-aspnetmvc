using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.EfRepositories;
using SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteById(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void MakeNewOrder(Order order)
        {
            if (order.PizzaOrders == null || order.PizzaOrders.Count < 1)
                throw new ArgumentNullException("Pizza Value in Order cannot be null");
            _orderRepository.Insert(order);
        }

        public void UpdateExistingOrder(Order order)
        {
            if (order.PizzaOrders == null || order.PizzaOrders.Count < 1)
                throw new ArgumentNullException("Pizza Value in Order cannot be null");
            _orderRepository.Update(order);
        }
    }
}
