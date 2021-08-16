using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PaymentMethod = order.PaymentMethod,
                Price = order.Pizza.IsOnPromotion ? 300 : order.Pizza.Price, //calculation for discount,
                Delivered = order.Delivered,
                Id = order.Id
            };
        }

        public static OrderListViewModel OrderToOrderListViewModel(Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            };
        }

        public static Order ToOrder(OrderViewModel orderViewModel)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            return new Order
            {
                Delivered = orderViewModel.Delivered,
                PaymentMethod = orderViewModel.PaymentMethod,
                Id = orderViewModel.Id,
                User = userDb,
                Pizza = pizzaDb
            };
        }

        public static OrderViewModel OrderToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserId = order.User.Id
            };
        }
    }
}
