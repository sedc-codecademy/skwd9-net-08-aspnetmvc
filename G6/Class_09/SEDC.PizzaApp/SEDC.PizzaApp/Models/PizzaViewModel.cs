using SEDC.PizzaApp.Domain.Enums;

namespace SEDC.PizzaApp.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
