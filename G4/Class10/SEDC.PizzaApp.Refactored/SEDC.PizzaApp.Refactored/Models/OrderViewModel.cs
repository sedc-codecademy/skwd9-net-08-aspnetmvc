using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public bool IsDelivered { get; set; }
        public double DeliveryPrice { get; set; }
        public List<PizzaViewModel> Pizzas { get; set; }
        public List<string> AvailablePizzas { get; set; }
    }
}
