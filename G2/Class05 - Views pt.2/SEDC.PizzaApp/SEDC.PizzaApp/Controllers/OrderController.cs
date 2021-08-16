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

            //ViewData["Message"] = $"The number of orders is: {ordersDb.Count}";
            ViewData["Message"] = StaticDb.Message; 
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
            //ViewBag.Message = "You are on the order details page";
            ViewBag.Message = StaticDb.Message;
            ViewBag.User = StaticDb.Users.First();
            //orderDb -> DB
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                //return new EmptyResult();
                return View("ResourceNotFound"); //first look in Order folder, then in Shared
            }
            //view model -> data to the view
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult CreateOrder()
        {
            //we have to send an empty model so that the form data is packed into that kind of model when it is sent via post
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserSelectViewModel(x)).ToList();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            //increment the id in the database
            orderViewModel.Id = StaticDb.Orders.Last().Id + 1;
            //validate if user with the selected id exists
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if(userDb == null)
            {
                return View("ResourceNotFound");
            }
            //validate if pizza with the entered name exists
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //we add only domain models in the database
            StaticDb.Orders.Add(OrderMapper.ToOrder(orderViewModel));

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }
            //we have to send the users, so that <option> items are generated in the select list for users
            //the right user is bound by mapping the UserId from the view model with the value attribute from the <option> tags
            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserSelectViewModel(x)).ToList();
            OrderViewModel orderViewModel = OrderMapper.OrderToOrderViewModel(orderDb);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }
            //validate if user with the selected id exists
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }
            //validate if pizza with the entered name exists
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).PaymentMethod = orderViewModel.PaymentMethod;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Delivered = orderViewModel.Delivered;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).User = userDb;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Pizza = pizzaDb;


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                //return new EmptyResult();
                return View("ResourceNotFound"); //first look in Order folder, then in Shared
            }
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult ConfirmDelete(int? id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            //check if the order exists
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }
            StaticDb.Orders.Remove(orderDb);
            return RedirectToAction("Index");
        }
    }
}
