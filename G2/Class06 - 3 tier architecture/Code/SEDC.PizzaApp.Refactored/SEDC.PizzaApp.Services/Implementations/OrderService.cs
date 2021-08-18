using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public List<OrderListViewModel> GetAllOrders()
        {
            //get all orders from db
            List<Order> dbOrders = _orderRepository.GetAll();

            //map all orders to view models
            return dbOrders.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();
        }
    }
}
