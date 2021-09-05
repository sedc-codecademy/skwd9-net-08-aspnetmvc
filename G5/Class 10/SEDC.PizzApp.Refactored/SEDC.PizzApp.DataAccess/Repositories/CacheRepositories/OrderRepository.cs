using SEDC.PizzApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzApp.DataAccess.Repositories.CacheRepositories
{
   public class OrderRepository : IRepository<Order>
   {
      public void DeleteById(int id)
      {
         var order = CacheDb.Orders.FirstOrDefault(o => o.Id == id);

         if (order != null)
         {
            CacheDb.Orders.Remove(order);
         }
      }

      public List<Order> GetAll()
      {
         return CacheDb.Orders;
      }

      public Order GetById(int id)
      {
         return CacheDb.Orders.FirstOrDefault(order => order.Id == id);
      }

      public int Insert(Order entity)
      {
         CacheDb.OrderId++;

         entity.Id = CacheDb.OrderId;

         CacheDb.Orders.Add(entity);

         return entity.Id;
      }

      public void Update(Order entity)
      {
         var order = CacheDb.Orders.FirstOrDefault(o => o.Id == entity.Id);

         if (order != null)
         {
            var index = CacheDb.Orders.IndexOf(entity);

            CacheDb.Orders[index] = entity;
         }
      }
   }
}