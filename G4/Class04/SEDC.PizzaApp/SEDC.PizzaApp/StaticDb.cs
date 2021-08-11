using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static List<Order> Orders;
        public static List<User> Users;
        public static List<Pizza> Menu;

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
            Menu = new List<Pizza>()
            {
                new Pizza()
                {
                    Id = 1,
                    Name = "Pepperoni",
                    Price = 200,
                    Size = PizzaSize.Small
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Price = 250,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Pepperoni",
                    Price = 350,
                    Size = PizzaSize.Family
                },
                new Pizza()
                {
                    Id = 4,
                    Name = "Margherita",
                    Price = 160,
                    Size = PizzaSize.Small
                },
                new Pizza()
                {
                    Id = 5,
                    Name = "Margherita",
                    Price = 200,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 6,
                    Name = "Margherita",
                    Price = 240,
                    Size = PizzaSize.Large
                },
                new Pizza()
                {
                    Id = 7,
                    Name = "Margherita",
                    Price = 280,
                    Size = PizzaSize.Family
                }
            };

            Orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    User = Users[0],
                    Pizza = Menu[2],
                    IsDelivered = true,
                    DeliveryPrice = 50
                },
                new Order()
                {
                    Id = 2,
                    User = Users[1],
                    Pizza = Menu[4],
                    IsDelivered = false,
                    DeliveryPrice = 20
                },
                new Order()
                {
                    Id = 3,
                    User = Users[1],
                    Pizza = Menu[0],
                    IsDelivered = true,
                    DeliveryPrice = 20
                }
            };
        }
    }
}
