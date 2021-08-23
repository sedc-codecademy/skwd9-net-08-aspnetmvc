using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.CacheRepository
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void DeleteById(int id)
        {
            Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                CacheDb.Pizzas.Remove(pizza);
            }
        }

        public List<Pizza> GetAll()
        {
            return CacheDb.Pizzas.ToList();
        }

        //implementation with arrow function
        //public List<Pizza> GetAll() => CacheDb.Pizzas.ToList();

        public Pizza GetById(int id)
        {
            return CacheDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Pizza entity)
        {
            CacheDb.PizzaId++;
            entity.Id = CacheDb.PizzaId;
            CacheDb.Pizzas.Add(entity);
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
            if (pizza != null)
            {
                //updating record by index
                int indexOfRecord = CacheDb.Pizzas.IndexOf(pizza);
                CacheDb.Pizzas[indexOfRecord] = entity;

                //updating record by property
                //pizza.Name = entity.Name;
                //pizza.IsOnPromotion = entity.IsOnPromotion;
                //pizza.PizzaSize = entity.PizzaSize;
                //pizza.Price = entity.Price;          
            }
        }
    }
}
