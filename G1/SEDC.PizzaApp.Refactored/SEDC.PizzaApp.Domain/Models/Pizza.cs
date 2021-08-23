using SEDC.PizzaApp.Domain.Enums;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnPromotion { get; set; }
        public double Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
