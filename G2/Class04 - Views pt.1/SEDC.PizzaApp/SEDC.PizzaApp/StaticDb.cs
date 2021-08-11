using SEDC.PizzaApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static string Message = "Message 1";
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                Name="Capri",
                Price = 350,
                IsOnPromotion = true
            },
            new Pizza
            {
                Id = 2,
                Name="Margarita",
                Price = 380,
                IsOnPromotion = false
            }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Tanja",
                LastName = "Stojanovska",
                Address = "Adresa1"
            },
            new User
            {
                Id = 2,
                FirstName = "Aleksandar",
                LastName = "Manasiev",
                Address = "Adresa2"
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id =1,
                Pizza = Pizzas.First(),
                User = Users.First(),
                PaymentMethod = Models.Enums.PaymentMethod.Card,
                Delivered = true
            },
            new Order
            {
                Id =2 ,
                Pizza = Pizzas.Last(),
                User = Users.Last(),
                PaymentMethod = Models.Enums.PaymentMethod.Cash,
                Delivered = false
            }
        };
    }
}
