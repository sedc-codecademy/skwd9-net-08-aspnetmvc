using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzApp.Models
{
   // View model
   public class UserViewModel
   {
      [Display(Name = "First name of user: ")]
      public string FirstName { get; set; }

      [Display(Name = "Last name of user: ")]
      public string LastName { get; set; }
   }
}