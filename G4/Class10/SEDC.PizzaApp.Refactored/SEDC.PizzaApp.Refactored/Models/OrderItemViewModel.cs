using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Models
{
    public class OrderItemViewModel
    {
        public int OrderId { get; set; }
        public string User { get; set; }
        //public string Pizza { get; set; }
        public int PizzaCount { get; set; }
    }
}
