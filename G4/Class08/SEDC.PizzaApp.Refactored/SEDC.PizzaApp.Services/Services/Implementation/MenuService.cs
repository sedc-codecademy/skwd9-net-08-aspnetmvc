using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public MenuService()
        {
            _pizzaRepository = new PizzaRepository();
        }

        public List<Pizza> GetMenu()
        {
            return _pizzaRepository.GetAll();
        }

        public Pizza GetPizzaFromMenu(string pizzaName, PizzaSize size)
        {
            List<Pizza> menu = _pizzaRepository.GetAll();
            return menu.FirstOrDefault(x => x.Name == pizzaName && x.Size == size);
        }
    }
}
