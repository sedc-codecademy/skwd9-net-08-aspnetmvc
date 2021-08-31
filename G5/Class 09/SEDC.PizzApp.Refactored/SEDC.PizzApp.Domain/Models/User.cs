using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzApp.Domain.Models
{
   public class User
   {
      public int Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Address { get; set; }

      public long Phone { get; set; }

      public List<Order> Orders { get; set; }
   }
}
