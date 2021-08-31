using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private IRepository<Order> _orderRepostory;

        public PizzaOrderService(IRepository<Order> orderRepository)
        {
            _orderRepostory = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepostory.GetAll().ToList();
        }

        public void MakeNewOrder(User user, List<Pizza> pizzas)
        {
            Order order = new Order();
            order.User = user;
            order.PizzaOrders = new List<PizzaOrder>();

            foreach (Pizza item in pizzas)
            {
                PizzaOrder pizzaOrder = new PizzaOrder
                {
                    Order = order,
                    Pizza = item
                };

                order.PizzaOrders.Add(pizzaOrder);
            }

            _orderRepostory.Insert(order);
        }
    }
}
