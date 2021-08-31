using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories
{
    public class PizzaEntityRepository : IRepository<Pizza>
    {
        private PizzaDbContext _db;
        public PizzaEntityRepository(PizzaDbContext db)
        {
            _db = db;
        }
        public void DeleteById(int id)
        {
            Pizza pizza = _db.Pizzas.SingleOrDefault(x => x.Id == id);
            if(pizza != null)
            {
                _db.Pizzas.Remove(pizza);
                _db.SaveChanges();
            }
        }

        public List<Pizza> GetAll()
        {
            return _db.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _db.Pizzas.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            _db.Pizzas.Add(entity);
            int id = _db.SaveChanges();
            return id;
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = _db.Pizzas.SingleOrDefault(x => x.Id == entity.Id);
            if(pizza != null)
            {
                entity.Id = pizza.Id;
                _db.Pizzas.Update(entity);
            }
        }
    }
}
