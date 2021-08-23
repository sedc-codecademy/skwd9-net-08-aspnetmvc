using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Services.Interface;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IPizzaOrderService _pizzaService;

        public OrderController(IPizzaOrderService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
