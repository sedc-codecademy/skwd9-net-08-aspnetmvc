using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string User { get; set; }

        public string Pizza { get; set; }

        public bool IsDelivered { get; set; }

        public double DeliveryPrice { get; set; }
    }
}
