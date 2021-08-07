using SEDC.AspNet.Mvc.Class03.App.Models.DataAccessModels;
using SEDC.AspNet.Mvc.Class03.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class03.App.Database
{
    public static class PizzaDatabase
    {
        public static List<User> Users { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Address> Addresses { get; set; }
        public static List<NewsletterSubscription> NewsletterSubscription { get; set; }
        public static List<Pizza> Pizzas { get; set; }

        static PizzaDatabase()
        {
            Users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "Trajan",
                    LastName = "Stevkovski",
                    Phone = 071609060,
                    NewsletterId = 1,
                    AddressId = 1
                }
            };
            Orders = new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    PizzaId = 2,
                    Delivered = true,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    PizzaId = 3,
                    Delivered = true,
                    UserId = 1
                },
                new Order
                {
                    Id = 3,
                    PizzaId = 1,
                    Delivered = false,
                    UserId = 1
                },
            };
            Addresses = new List<Address>()
            {
                new Address
                {
                    Id = 1,
                    Name = "Skopje sk",
                    UserId = 1
                }
            };
            NewsletterSubscription = new List<NewsletterSubscription>()
            {
                new NewsletterSubscription
                {
                    Id = 1,
                    IsSubscribed = true,
                    UserId = 1
                }
            };
            Pizzas = new List<Pizza>()
            {
                new Pizza()
                {
                    Id = 1,
                    Name = "Kapri",
                    Price = 7,
                    Size = PizzaSize.Medium
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Kapri",
                    Price = 8,
                    Size = PizzaSize.Large
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Kapri",
                    Price = 9,
                    Size = PizzaSize.Family
                }
            };
        }
    }
}
