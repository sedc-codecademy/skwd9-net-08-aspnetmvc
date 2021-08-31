using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.DataAccess.Repositories.EntityRepositories
{
   public class OrderEntityRepository : IRepository<Order>
   {
      private PizzaDbContext _context;
      public OrderEntityRepository(PizzaDbContext context)
      {
         _context = context;
      }
      public void DeleteById(int id)
      {
         Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
         if (order != null) _context.Orders.Remove(order);
         _context.SaveChanges();
      }
 
      public List<Order> GetAll()
      {
         return _context.Orders
            .Include(x => x.PizzaOrders)
            .ThenInclude(x => x.Pizza)
            .Include(x => x.User)
            .ToList();
      }
 
      public Order GetById(int id)
      {
         return _context.Orders
            .Include(i => i.PizzaOrders)
            .ThenInclude(i => i.Pizza)
            .Include(i => i.User)
            .FirstOrDefault(x => x.Id == id);
      }
 
      public int Insert(Order entity)
      {
         _context.Orders.Add(entity);
         int id = _context.SaveChanges();
         return id;
      }
 
      public void Update(Order entity)
      {
         Order order = _context.Orders.FirstOrDefault(x => x.Id == entity.Id);
         if (order != null)
         {
            entity.Id = order.Id;
            _context.Orders.Update(entity);
         }
      }
   }
}