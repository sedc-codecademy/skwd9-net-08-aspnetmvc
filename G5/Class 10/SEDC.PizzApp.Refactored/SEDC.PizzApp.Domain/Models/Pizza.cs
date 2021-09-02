using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.PizzApp.Domain.Enums;

namespace SEDC.PizzApp.Domain.Models
{
   public class Pizza
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public PizzaSize Size { get; set; }

      public double Price { get; set; }

      public string Image { get; set; }

      public List<PizzaOrder> PizzaOrders { get; set; }
   }
}
