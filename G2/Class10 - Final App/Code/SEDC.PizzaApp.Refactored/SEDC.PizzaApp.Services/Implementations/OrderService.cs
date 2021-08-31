using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.Shared.CustomExceptions;
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
        //private IRepository<Pizza> _pizzaRepository;
        private IPizzaRepository _pizzaRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository, IPizzaRepository pizzaRepository)
        {
            //_orderRepository = new OrderRepository();
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel)
        {
            Pizza pizzaDb = _pizzaRepository.GetById(pizzaOrderViewModel.PizzaId);
            if(pizzaDb == null)
            {
                //log
                throw new Exception($"Pizza with id {pizzaOrderViewModel.PizzaId} was not found");
            }
            Order orderDb = _orderRepository.GetById(pizzaOrderViewModel.OrderId);
            if (orderDb == null)
            {
                //log
                throw new Exception($"Order with id {pizzaOrderViewModel.OrderId} was not found");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                PizzaSize = pizzaOrderViewModel.PizzaSize
            });
            _orderRepository.Update(orderDb);
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

            int numOfInsertedRecords = _orderRepository.Insert(order);
            if(numOfInsertedRecords <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

        public void DeleteOrder(int id)
        {
            //validations
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            _orderRepository.DeleteById(id);
        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            //validations
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {orderViewModel.Id} was not found!");
            }
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new ResourceNotFoundException($"The user with id {orderViewModel.UserId} was not found!");
            }

            //this way a new record will be created in the Users table 
            //orderDb.User = new User
            //{
            //    FirstName = "Test",
            //    LastName = "Test",
            //    Address = "Test"
            //};

            //edit the existing record

            orderDb.User = userDb;
            
            orderDb.Delivered = orderViewModel.Delivered;
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.Location = orderViewModel.Location;
            //we send the edited domain model for update
            _orderRepository.Update(orderDb);
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

        public OrderViewModel GetOrderForEditing(int id)
        {
            //get from db
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            //return mapped view model
            return orderDb.ToOrderViewModel();
        }
    }
}
