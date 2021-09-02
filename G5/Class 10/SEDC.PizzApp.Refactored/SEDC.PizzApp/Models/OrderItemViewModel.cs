using System.Collections.Generic;

namespace SEDC.PizzApp.Refactored.Models
{
   public class OrderItemViewModel
   {
      public int Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public double Price { get; set; }

      public List<PizzaViewModel> Pizzas { get; set; } = new List<PizzaViewModel>();
   }
}