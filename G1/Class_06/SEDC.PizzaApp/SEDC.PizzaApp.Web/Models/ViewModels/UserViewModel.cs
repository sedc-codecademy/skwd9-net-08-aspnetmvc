using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FullName { get; set; }
    }
}
