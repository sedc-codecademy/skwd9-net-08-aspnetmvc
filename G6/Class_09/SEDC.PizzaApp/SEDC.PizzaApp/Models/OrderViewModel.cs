using System.Collections.Generic;

namespace SEDC.PizzaApp.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Pizzas = new List<PizzaViewModel>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public List<PizzaViewModel> Pizzas { get; set; }
    }
}
