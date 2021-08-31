using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services
{
    public interface IPizzaOrderService
    {
        public void MakeNewOrder(User user, List<Pizza> pizzas);

        public List<Order> GetAllOrders();
    }
}
