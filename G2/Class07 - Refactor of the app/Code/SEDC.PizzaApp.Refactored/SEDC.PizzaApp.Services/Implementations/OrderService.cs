using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            //_orderRepository = new OrderRepository();
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if(userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            }
            Order order = orderViewModel.ToOrder();
            order.User = userDb;

            int newOrderId = _orderRepository.Insert(order);
            if(newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            //get all orders from db
            List<Order> dbOrders = _orderRepository.GetAll();

            //map all orders to view models
            return dbOrders.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                //log
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.ToOrderDetailsViewModel();
        }
    }
}
