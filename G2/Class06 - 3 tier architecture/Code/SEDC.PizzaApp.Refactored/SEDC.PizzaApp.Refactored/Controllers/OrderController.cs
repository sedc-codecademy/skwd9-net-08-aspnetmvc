using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }
    }
}
