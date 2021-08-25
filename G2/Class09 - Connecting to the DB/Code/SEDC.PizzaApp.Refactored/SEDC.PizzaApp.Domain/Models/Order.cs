using SEDC.PizzaApp.Domain.Enums;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string Location { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
