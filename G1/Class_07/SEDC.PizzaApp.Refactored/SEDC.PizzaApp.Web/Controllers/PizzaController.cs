using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Services.Interface;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            var pizzas = _pizzaService.GetAllPizzas();
           
            return View(pizzas);
        }
    }
}
