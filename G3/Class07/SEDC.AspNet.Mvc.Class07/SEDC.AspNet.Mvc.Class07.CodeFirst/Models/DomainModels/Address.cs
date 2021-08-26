using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
