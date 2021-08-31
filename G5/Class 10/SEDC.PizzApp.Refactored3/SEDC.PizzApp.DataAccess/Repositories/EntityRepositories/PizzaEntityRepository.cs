using System.Collections.Generic;
using System.Linq;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.DataAccess.Repositories.EntityRepositories
{
   public class PizzaEntityRepository : IRepository<Pizza>
   {
      private PizzaDbContext _context;
      public PizzaEntityRepository(PizzaDbContext context)
      {
         _context = context;
      }
      public void DeleteById(int id)
      {
         Pizza pizza = _context.Pizzas.FirstOrDefault(x => x.Id == id);
         if (pizza != null) _context.Pizzas.Remove(pizza);
         _context.SaveChanges();
      }
 
      public List<Pizza> GetAll()
      {
         return _context.Pizzas.ToList();
      }
 
      public Pizza GetById(int id)
      {
         return _context.Pizzas.FirstOrDefault(x => x.Id == id);
      }
 
      public int Insert(Pizza entity)
      {
         _context.Pizzas.Add(entity);
         int id = _context.SaveChanges();
         return id;
      }
 
      public void Update(Pizza entity)
      {
         Pizza pizza = _context.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
         if (pizza != null)
         {
            entity.Id = pizza.Id;
            _context.Pizzas.Update(entity);
         }
      }
   }
}