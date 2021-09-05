using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Web.Models
{
    public class OrderViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public long Phone { get; set; }
        public List<PizzaViewModel> Pizzas { get; set; }
    }
}
