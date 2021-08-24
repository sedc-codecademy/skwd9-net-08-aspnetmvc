using SEDC.PizzApp.Enums;

namespace SEDC.PizzApp.Refactored.Models
{
   public class Player
   {
      public int PlayerId { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public Position Position { get; set; }

      public double Salary { get; set; }
   }
}