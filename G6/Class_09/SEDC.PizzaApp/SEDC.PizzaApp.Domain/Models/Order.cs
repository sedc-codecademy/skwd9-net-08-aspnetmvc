using System.Collections.Generic;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
