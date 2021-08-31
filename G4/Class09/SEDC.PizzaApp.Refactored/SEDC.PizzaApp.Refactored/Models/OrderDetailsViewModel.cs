using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Models
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string User { get; set; }
        public string Pizza { get; set; }
        public bool IsDelivered { get; set; }
        public double DeliveryPrice { get; set; }
    }
}
