using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public bool IsSubscribed { get; set; }
        public double TotalSpendings { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
