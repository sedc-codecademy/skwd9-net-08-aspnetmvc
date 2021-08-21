using SEDC.PizzaApp.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [Display(Name = "Is Delivered")]
        public bool Delivered { get; set; }
        [Display(Name = "Order Location")]
        public string Location { get; set; }
        [Display(Name = "User")]
        public string UserFullName { get; set; }
        [Display(Name = "Pizzas")]
        public List<string> PizzaNames { get; set; }
    }
}
