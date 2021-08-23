using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System.Linq;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel OrderToOrderListViewModel(Order order)
        {
            return new OrderListViewModel
            {
                Delivered = order.Delivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }
    }
}
