using SEDC.PizzApp.Enums;

namespace SEDC.PizzApp.Models
{
   public class NewOrderViewModel
   {
      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string PizzaName { get; set; }

      public Size PizzaSize { get; set; }
   }
}