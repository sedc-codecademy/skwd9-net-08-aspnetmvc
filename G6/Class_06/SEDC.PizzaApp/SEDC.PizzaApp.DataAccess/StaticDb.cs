using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.DataAccess
{
    public class StaticDb
    {
        public List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza
            {
                Id = 1,
                Name = "Capricciosa",
                Price = 300,
                Size = PizzaSize.Medium
            }
        };

        public List<User> Users = new List<User>() { 
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
