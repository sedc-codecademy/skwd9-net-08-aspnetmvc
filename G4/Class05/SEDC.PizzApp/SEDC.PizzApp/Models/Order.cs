using SEDC.PizzApp.Enums;

namespace SEDC.PizzApp.Models
{
   // Domain Model
   public class Order
   {
      public Order()
      {
         Id = 1;
         Pizza = "Kapriciosa";
         Price = 11;
         Delivered = false;
      }

      public int Id { get; set; }

      public User User { get; set; }

      public string Pizza { get; set; }

      public double Price { get; set; }

      public bool Delivered { get; set; }

      public Size Size { get; set; }
   }
}