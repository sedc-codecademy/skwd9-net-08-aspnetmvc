using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public static class StaticDb
    {
        public static List<Order> Orders;
        public static List<User> Users;

        static StaticDb()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Jankuloski",
                    Address = "Street 01",
                    Phone = 38977123456
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "Unknown",
                    Phone = 38977654321
                }
            };
            Orders = new List<Order>()
            {
                new Order()
                {
                    OrderId = 1,
                    User = "Martin Jankuloski",
                    Pizza = "Prosciutto",
                    DeliveryPrice = 40,
                    IsDelivered = false
                },
                new Order()
                {
                    OrderId = 2,
                    User = "Jane Doe",
                    Pizza = "Capri",
                    DeliveryPrice = 30,
                    IsDelivered = true
                }
            };
        }
    }
}
