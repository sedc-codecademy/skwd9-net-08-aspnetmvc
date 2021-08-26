using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SEDC.AspNet.Mvc.Class07.DatabaseFirst.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Orders>();
        }

        public int OrderStatusId { get; set; }
        public byte Status { get; set; }
        public int ChangedBy { get; set; }
        public DateTime LastChange { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
