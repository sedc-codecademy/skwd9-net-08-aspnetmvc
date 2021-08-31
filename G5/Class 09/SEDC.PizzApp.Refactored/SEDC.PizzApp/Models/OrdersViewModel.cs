using System.Collections.Generic;

namespace SEDC.PizzApp.Refactored.Models
{
   public class OrdersViewModel
   {
      public List<OrderItemViewModel> Orders { get; set; }

      public int OrderCount { get; set; }

      public string LastPizza { get; set; }

      public string MostPopularPizza { get; set; }

      public string NameOfFirstCustomer { get; set; }
   }
}