using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Models.Mapper
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                Price = order.Price,
                Delivered = order.Delivered,
                PizzaStore = order.PizzaStore
            };
        }

        public static OrderViewModel OrderToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                PizzaStore = order.PizzaStore,
                Price = order.Price,
                Delivered = order.Delivered,
                UserId = order.User.Id
            };
        }
    }
}
