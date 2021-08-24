using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainModels.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public int Price { get; set; }
    }
}
