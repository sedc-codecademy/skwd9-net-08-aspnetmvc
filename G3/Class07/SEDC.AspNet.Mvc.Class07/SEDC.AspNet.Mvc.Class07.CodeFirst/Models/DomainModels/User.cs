using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
    }
}
