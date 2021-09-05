using SEDC.AspNet.Mvc.PizzaApp.Domain.Enums;
using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels
{
    public class CreateOrderVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string PizzaName { get; set; }
        public PizzaSize Size { get; set; }
        //public List<PizzaVM> Pizzas { get; set; }
    }
}
