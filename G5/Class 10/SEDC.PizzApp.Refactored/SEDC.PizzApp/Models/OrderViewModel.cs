using System.Collections.Generic;

namespace SEDC.PizzApp.Refactored.Models
{
   public class OrderViewModel
   {
      public OrderViewModel()
      {
         ChosenPizzas = new List<PizzaViewModel>();
      }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Address { get; set; }

      public long Phone { get; set; }

      public List<PizzaViewModel> ChosenPizzas { get; set; }
   }
}