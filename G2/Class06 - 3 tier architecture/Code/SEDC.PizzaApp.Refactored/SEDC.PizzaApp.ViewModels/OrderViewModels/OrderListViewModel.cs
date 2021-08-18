
using System.Collections.Generic;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public string UserFullName { get; set; }
        public bool Delivered { get; set; }
        public List<string> PizzaNames { get; set; }
    }
}
