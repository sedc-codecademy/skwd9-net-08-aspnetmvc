using SEDC.PizzApp.Domain.Enums;

namespace SEDC.PizzApp.Refactored.Models
{
   public class PizzaViewModel
   {
      public int? Id { get; set; }

      public string PizzaName { get; set; }

      public double Price { get; set; }

      public PizzaSize Size { get; set; }

      public string Image { get; set; }
   }
}