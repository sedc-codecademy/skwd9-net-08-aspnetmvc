using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzApp.Domain.Models
{
   public class Order
   {
      public int Id { get; set; }

      public User User { get; set; }

      public int UserId { get; set; }

      public List<PizzaOrder> PizzaOrders { get; set; }

      public double Price { get; set; }
   }
}
