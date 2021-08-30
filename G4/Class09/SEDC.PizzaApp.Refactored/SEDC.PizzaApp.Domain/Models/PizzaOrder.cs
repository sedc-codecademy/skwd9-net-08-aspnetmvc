using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class PizzaOrder
    {
        public int PizzaOrderId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
    }
}
