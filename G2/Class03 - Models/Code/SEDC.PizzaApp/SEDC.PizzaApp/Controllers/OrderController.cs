using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {

            List<Order> ordersDb = StaticDb.Orders;
            List<OrderListViewModel> orderListViewModels = ordersDb
                .Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();

            //List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>();
            //foreach(Order orderDb in ordersDb)
            //{
            //    orderListViewModels.Add(OrderMapper.OrderToOrderListViewModel(orderDb));
            //}

            ViewData["Message"] = $"The number of orders is: {ordersDb.Count}";
            ViewData["Title"] = "Orders list";
            ViewData["Date"] = DateTime.Now.ToShortDateString();

            ViewData["FirstUser"] = StaticDb.Users.First();

            return View(orderListViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            ViewBag.Message = "You are on the order details page";
            ViewBag.User = StaticDb.Users.First();
            //orderDb -> DB
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return new EmptyResult();
            }
            //view model -> data to the view
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }
    }
}
