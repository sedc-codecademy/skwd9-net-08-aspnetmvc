using SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.ViewModels
{
    public class OrderListVM
    {
        public string FirstPizza { get; set; }
        public int NumberOfOrders { get; set; }
        public string FirstCustomerName { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
