using SEDC.AspNet.Mvc.Class03.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Models.DataTransferModels
{
    public class PizzaDto
    {
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
    }
}
