using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        //public List<Pizza> Pizzas { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public bool IsDelivered { get; set; }
        public double DeliveryPrice { get; set; }
    }
}
