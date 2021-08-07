using SEDC.PizzaApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
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
    }
}
