using SEDC.PizzApp.Refactored.Models;

namespace SEDC.PizzApp.Models
{
   // A view model
   public class OrderDetailsViewModel
   {
      public string Address { get; set; }

      public long Phone { get; set; }

      public OrderItemViewModel Order { get; set; }
   }
}