using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<OrderItemVM> Orders { get; set; }
        public int OrderCount { get; set; }
        public string LastPizza { get; set; }
        public string MostPopularPizza { get; set; }
        public string NameOfFirstCustomer { get; set; }
        public string Currency { get; set; }
    }
}
