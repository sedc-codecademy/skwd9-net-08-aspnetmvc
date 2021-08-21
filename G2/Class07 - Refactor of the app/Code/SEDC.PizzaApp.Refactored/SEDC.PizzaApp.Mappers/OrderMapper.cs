using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel OrderToOrderListViewModel(Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }
        //extension method of Order
        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                Location = order.Location,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Delivered = orderViewModel.Delivered,
                Location = orderViewModel.Location,
                PaymentMethod = orderViewModel.PaymentMethod,
                PizzaOrders = new List<PizzaOrder>(),
                UserId = orderViewModel.UserId
            };
        }
    }
}
