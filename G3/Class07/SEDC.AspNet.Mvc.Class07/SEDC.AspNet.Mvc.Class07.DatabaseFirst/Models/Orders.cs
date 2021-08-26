using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SEDC.AspNet.Mvc.Class07.DatabaseFirst.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
