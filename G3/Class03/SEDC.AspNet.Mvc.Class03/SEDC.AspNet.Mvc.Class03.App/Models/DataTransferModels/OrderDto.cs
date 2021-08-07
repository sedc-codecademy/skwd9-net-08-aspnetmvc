using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public bool Delivered { get; set; }

        public PizzaDto Pizza { get; set; }
    }
}
