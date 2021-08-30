using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly PizzaContext _context;

        public PizzaRepository(PizzaContext pizzaContext)
        {
            _context = pizzaContext;
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public List<Pizza> GetByFilter(Func<Pizza, bool> filter)
        {
            return _context.Pizzas.Where(filter).ToList();
        }

        public Pizza GetById(int id)
        {
            return _context.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            _context.Pizzas.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var pizza = _context.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza != null)
            {
                _context.Pizzas.Remove(pizza);
            }
            _context.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            _context.Pizzas.Update(entity);
            _context.SaveChanges();
        }
    }
}
