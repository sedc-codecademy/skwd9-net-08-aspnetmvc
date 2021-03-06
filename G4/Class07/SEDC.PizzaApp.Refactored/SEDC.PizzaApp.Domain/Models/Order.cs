using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public User User { get; set; }

        public Pizza Pizza { get; set; }

        public bool IsDelivered { get; set; }

        public double DeliveryPrice { get; set; }
    }
}
