using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels
{
    public class MenuVM
    {
        public IEnumerable<PizzaVM> Pizzas { get; set; }

        // additional data for View
        public string Currency { get; set; }
    }
}
