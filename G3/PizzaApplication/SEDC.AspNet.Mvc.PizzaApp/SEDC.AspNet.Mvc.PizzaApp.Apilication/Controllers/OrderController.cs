using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces;

namespace SEDC.AspNet.Mvc.PizzaApp.Apilication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaOrderService _pizzaOrderService;

        public OrderController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        public IActionResult Index()
        {
            return View(_pizzaOrderService.GetOrders());
        }
    }
}
