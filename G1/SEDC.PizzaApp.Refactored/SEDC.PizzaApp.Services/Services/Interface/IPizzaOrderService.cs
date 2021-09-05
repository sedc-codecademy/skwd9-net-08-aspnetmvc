using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Services.Interface
{
    public interface IPizzaOrderService
    {
        List<Pizza> GetMenu();
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        int GetOrderCount();
        string GetMostPopularPizza();
        Order GetLastOrder();
        void MakeNewOrder(Order order);
        Pizza GetPizzaFromMenu(string pizzaName, PizzaSize pizzaSize);
    }
}
