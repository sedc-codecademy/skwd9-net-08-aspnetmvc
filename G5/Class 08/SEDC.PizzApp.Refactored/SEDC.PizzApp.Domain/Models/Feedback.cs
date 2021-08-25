using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzApp.Domain.Models
{
   public class Feedback
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public string Email { get; set; }

      public string Message { get; set; }
   }
}
