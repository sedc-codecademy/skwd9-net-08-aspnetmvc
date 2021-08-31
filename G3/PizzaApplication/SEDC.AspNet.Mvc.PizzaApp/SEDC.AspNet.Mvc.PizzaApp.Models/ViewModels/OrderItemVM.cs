using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels
{
    public class OrderItemVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Price { get; set; }
        public IEnumerable<PizzaVM> Pizzas { get; set; }
    }
}
