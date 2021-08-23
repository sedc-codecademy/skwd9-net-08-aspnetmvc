using SEDC.PizzaApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Is Delivered")]
        public bool Delivered { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
    }
}
