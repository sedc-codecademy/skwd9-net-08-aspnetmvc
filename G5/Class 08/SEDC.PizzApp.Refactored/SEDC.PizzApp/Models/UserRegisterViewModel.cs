using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzApp.Models
{
   public class UserRegisterViewModel
   {
      [Display(Name = "First name: ")]
      public string FirstName { get; set; }

      [Display(Name = "Last name: ")]
      public string LastName { get; set; }

      [Display(Name = "Address: ")]
      public string Address { get; set; }
   }
}