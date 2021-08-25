using System;
using System.Collections.Generic;
using System.Linq;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.Domain.Enums;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.Services.Services
{
   public class PizzaOrderService : IPizzaOrderService
   {
      private IRepository<User> _userRepository;
      private IRepository<Order> _orderRepository;
      private IRepository<Pizza> _pizzaRepository;

      public PizzaOrderService(IRepository<User> userRepository,
         IRepository<Order> orderRepository,
         IRepository<Pizza> pizzaRepository)
      {
         _userRepository = userRepository;
         _orderRepository = orderRepository;
         _pizzaRepository = pizzaRepository;
      }

      public List<Order> GetAllOrders()
      {
         return _orderRepository.GetAll();
      }

      public Order GetLastOrder()
      {
         var orders = _orderRepository.GetAll();

         return orders[orders.Count - 1];
      }

      public List<Pizza> GetMenu()
      {
         return 
            _pizzaRepository.GetAll()
            .GroupBy(pizza => pizza.Name)
            .Select(pizza => pizza.First())
            .ToList();
      }

      public string GetMostPopularPizza()
      {
         // Get all orders
         var orders = _orderRepository.GetAll();

         // Flattening (all pizzas from all orders)
         var pizzaOrders = orders
            .SelectMany(order => order.PizzaOrders)
            .ToList();

         var mostPopularPizzaName = pizzaOrders
            .GroupBy(pizzaOrder => pizzaOrder.Pizza.Name) // We group by name
            // Order by descending so that the first element would be the pizza
            // that got ordered the most
            .OrderByDescending(pizzaOrder => pizzaOrder.Count())
            .FirstOrDefault()? // We take the first element i.e the pizza with the most orders
            .Select(pizzaOrder => pizzaOrder.Pizza.Name) // We take the pizza name from the pizza order
            .FirstOrDefault();

         return mostPopularPizzaName;
      }

      public Order GetOrderById(int id)
      {
         return _orderRepository.GetById(id);
      }

      public int GetOrderCount()
      {
         return _orderRepository.GetAll().Count;
      }

      public Pizza GetPizzaFromMenu(string name, PizzaSize size)
      {
         var menu = _pizzaRepository.GetAll();

         return menu.FirstOrDefault(pizza => (pizza.Name.Equals(name) && pizza.Size == size));
      }

      public void MakeNewOrder(Order order)
      {
         // TODO: Implement validation

         _orderRepository.Insert(order);
      }
   }
}