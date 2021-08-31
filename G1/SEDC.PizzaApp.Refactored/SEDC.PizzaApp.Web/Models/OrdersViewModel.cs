using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models
{
    public class OrdersViewModel
    {
        public int OrdersCount { get; set; }
        public string LastOrderedPizza { get; set; }
        public string MostPopularPizza { get; set; }
        public string NameOfFirstCustomer { get; set; }
        public List<OrderItemViewModel> Orders { get; set; }
    }
}
