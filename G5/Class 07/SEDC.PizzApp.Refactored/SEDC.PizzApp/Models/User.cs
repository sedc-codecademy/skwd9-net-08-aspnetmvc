namespace SEDC.PizzApp.Models
{
   // Domain Model
   public class User
   {
      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Address { get; set; }

      public long Phone { get; set; }

      public string GetFullName()
      {
         return FirstName + " " + LastName;
      }
   }
}