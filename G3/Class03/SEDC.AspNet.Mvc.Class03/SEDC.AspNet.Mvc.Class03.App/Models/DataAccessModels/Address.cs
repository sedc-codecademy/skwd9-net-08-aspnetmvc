using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataAccessModels
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
