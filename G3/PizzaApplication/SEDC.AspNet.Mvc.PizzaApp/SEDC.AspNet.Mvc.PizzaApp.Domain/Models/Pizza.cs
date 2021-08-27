using SEDC.AspNet.Mvc.PizzaApp.Domain.Enums;
using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        // Navigation Prop

        public virtual List<PizzaOrder> PizzaOrders { get; set; }
    }
}
