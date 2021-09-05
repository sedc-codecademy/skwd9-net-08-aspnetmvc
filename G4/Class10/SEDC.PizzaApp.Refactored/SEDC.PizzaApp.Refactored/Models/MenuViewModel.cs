using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Models
{
    public class MenuViewModel
    {
        public List<PizzaViewModel> Menu { get; set; } = new List<PizzaViewModel>();
    }
}
