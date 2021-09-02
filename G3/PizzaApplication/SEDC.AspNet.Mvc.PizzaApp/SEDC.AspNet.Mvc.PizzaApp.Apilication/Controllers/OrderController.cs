using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;

namespace SEDC.AspNet.Mvc.PizzaApp.Apilication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaOrderService _pizzaOrderService;
        private readonly IPizzaService _pizzaService;

        public OrderController(IPizzaOrderService pizzaOrderService,
            IPizzaService pizzaService)
        {
            _pizzaOrderService = pizzaOrderService;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            return View(_pizzaOrderService.GetOrders());
        }

        [HttpGet("OrderPizza")]
        public IActionResult OrderPizza()
        {
            //if (TempData["CreateOrderVM"] != null)
            //{
            //    return View(TempData["CreateOrderVM"] as CreateOrderVM);
            //}
            return View();
        }

        [HttpPost("OrderPizza")]
        public IActionResult OrderPizza(CreateOrderVM request)
        {
            var response = _pizzaOrderService.CreateOrder(request);

            if (response.IsSuccess)
            {
                return RedirectToAction("Index", "Order");
            }

            // TempData["CreateOrderVM"] = response.Order; // this needs to be serialized
            TempData["Error"] = response.ErrorMessage;

            return View(response.Order);
        }
    }
}
