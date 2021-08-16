using SEDC.PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pizza name is required")]
        [Display(Name = "The name of the pizza")]
        public string PizzaName { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
    }
}
