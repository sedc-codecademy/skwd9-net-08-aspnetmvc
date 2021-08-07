using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataAccessModels
{
    public class Order
    {
        public int Id { get; set; }
        public bool Delivered { get; set; }

        public int PizzaId { get; set; }
        public int UserId { get; set; }
    }
}
