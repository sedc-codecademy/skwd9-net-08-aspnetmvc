using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Services.Interfaces
{
    public interface IMenuService
    {
        List<Pizza> GetMenu();
        Pizza GetPizzaFromMenu(string pizzaName, PizzaSize size);
        List<string> GetPizzasInMenu();
    }
}
