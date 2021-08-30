using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; } // 1

        // navigation properties
        public virtual User User { get; set; } // user 
        public virtual List<PizzaOrder> PizzaOrders { get; set; } // null 

        // Price for all pizzas
        [NotMapped]
        public double Price
        {
            get
            {
                if(PizzaOrders != null)
                {
                    return PizzaOrders.Sum(x => x.Pizza.Price) + 2;
                }
                return 0;

                // other way 
                // return PizzaOrders?.Sum(x => x.Pizza.Price) + 2 ?? 0;
            }
        }
    }
}
