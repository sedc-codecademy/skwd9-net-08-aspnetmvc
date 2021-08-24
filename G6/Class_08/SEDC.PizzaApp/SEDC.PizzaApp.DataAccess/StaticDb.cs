using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.DataAccess
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
                new Pizza()
                {
                    Id = 1,
                    Name = "Kapri",
                    Price = 7,
                    Size = PizzaSize.Medium,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Kapri",
                    Price = 7,
                    Size = PizzaSize.Large,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Kapri",
                    Price = 7,
                    Size = PizzaSize.Family,
                    Image = "Kapri.png"
                },
                new Pizza()
                {
                    Id = 4,
                    Name = "Peperoni",
                    Price = 9,
                    Size = PizzaSize.Medium,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 5,
                    Name = "Peperoni",
                    Price = 8,
                    Size = PizzaSize.Large,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 6,
                    Name = "Peperoni",
                    Price = 8,
                    Size = PizzaSize.Family,
                    Image = "Peperoni.png"
                },
                new Pizza()
                {
                    Id = 7,
                    Name = "Margarita",
                    Price = 10.5,
                    Size = PizzaSize.Medium,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 8,
                    Name = "Margarita",
                    Price = 10.5,
                    Size = PizzaSize.Large,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 9,
                    Name = "Margarita",
                    Price = 10.5,
                    Size = PizzaSize.Family,
                    Image = "Margarita.png"
                },
                new Pizza()
                {
                    Id = 10,
                    Name = "Siciliana",
                    Price = 6.5,
                    Size = PizzaSize.Medium,
                    Image = "Siciliana.png"
                },
                new Pizza()
                {
                    Id = 11,
                    Name = "Siciliana",
                    Price = 9.5,
                    Size = PizzaSize.Large,
                    Image = "Siciliana.png"
                },
                new Pizza()
                {
                    Id = 12,
                    Name = "Siciliana",
                    Price = 9.5,
                    Size = PizzaSize.Family,
                    Image = "Siciliana.png"
                }
        };

        public static List<User> Users = new List<User>() {
            new User
            {
                Id = 1,
                FirstName = "Ljube",
                LastName = "Bajraktarov",
                Address = "Gevgelija",
                Phone = 78683293,
                Username = "ljube.bajraktarov"
            }
        };
    }
}
