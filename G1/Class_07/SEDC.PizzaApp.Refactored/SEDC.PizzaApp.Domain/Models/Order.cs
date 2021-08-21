using SEDC.PizzaApp.Domain.Enums;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public double Price { get; set; }
        public Pizza Pizza { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string PizzaStore { get; set; }
    }
}
