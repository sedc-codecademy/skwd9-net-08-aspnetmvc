using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzApp.Models
{
   // Domain Model
   public class User
   {
      [Display(Name = "First name on arabic: ")]
      public string FirstName { get; set; }

      [Display(Name = "Last name on arabic: ")]
      public string LastName { get; set; }

      public string Address { get; set; }

      public long Phone { get; set; }

      public string GetFullName()
      {
         return FirstName + " " + LastName;
      }
   }
}