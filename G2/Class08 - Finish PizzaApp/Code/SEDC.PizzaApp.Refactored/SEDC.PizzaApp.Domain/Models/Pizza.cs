using SEDC.PizzaApp.Domain.Enums;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public PizzaSizeEnum PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
