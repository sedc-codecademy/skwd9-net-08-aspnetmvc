using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
