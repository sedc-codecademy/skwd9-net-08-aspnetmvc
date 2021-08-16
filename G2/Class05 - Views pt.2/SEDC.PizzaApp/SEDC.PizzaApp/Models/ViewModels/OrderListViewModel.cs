using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string UserFullName { get; set; }
    }
}
