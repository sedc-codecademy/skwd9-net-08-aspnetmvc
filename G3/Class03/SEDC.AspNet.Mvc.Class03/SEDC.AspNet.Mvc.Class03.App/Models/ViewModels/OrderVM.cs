using SEDC.AspNet.Mvc.Class03.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.ViewModels
{
    public class OrderVM
    {
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Display(Name = "Address for delivery")]
        public string Address { get; set; }

        [Display(Name = "Contact information")]
        public long Phone { get; set; }

        [Display(Name = "Pizza")]
        public string PizzaName { get; set; }

        [Display(Name = "Pizza size")]
        public PizzaSize Size { get; set; }

        [Display(Name = "Status")]
        public bool Delivered { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
