using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public bool Delivered { get; set; }
        public int UserId { get; set; }

        // navigation properties
        public virtual User User { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
