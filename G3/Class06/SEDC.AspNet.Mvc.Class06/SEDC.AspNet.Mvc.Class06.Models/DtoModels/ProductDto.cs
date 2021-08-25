using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.Models.DtoModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public int Price { get; set; }
    }
}
