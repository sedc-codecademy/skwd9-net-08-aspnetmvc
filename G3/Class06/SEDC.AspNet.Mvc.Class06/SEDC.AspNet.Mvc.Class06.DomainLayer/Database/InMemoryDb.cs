using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Database
{
    public static class InMemoryDb
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User
            {
                Id = 1,
                Age = 22,
                FullName = "Trajan Stevkovski",
                Phone = 123123321
            }
        };
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product
            {
                Id = 1,
                DateOfManufacturing = DateTime.Now,
                Name = "Product",
                Price = 100
            }
        };
    }
}
