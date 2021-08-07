using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
