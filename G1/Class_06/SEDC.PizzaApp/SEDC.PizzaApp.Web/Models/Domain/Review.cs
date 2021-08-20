using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
