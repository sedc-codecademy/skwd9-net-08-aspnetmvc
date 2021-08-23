using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;
        public OrderController(IOrderService orderService, IUserService userService) //DependencyInjectionHelper -> map
        {
            //_orderService = new OrderService();
            _orderService = orderService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception e)
            {
                //log
                return View("ExceptionPage");

            }
        }

        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("ExceptionPage");
            }
        }
    }
}
