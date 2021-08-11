using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class MasterOrderListViewModel
    {
        public List<OrderListViewModel> DeliveredOrders { get; set; }
        public List<OrderListViewModel> PendingOrders { get; set; }

        public int CountOfDeliveredOrders { get; set; }
        public int CountOfPendingOrders { get; set; }
    }
}
