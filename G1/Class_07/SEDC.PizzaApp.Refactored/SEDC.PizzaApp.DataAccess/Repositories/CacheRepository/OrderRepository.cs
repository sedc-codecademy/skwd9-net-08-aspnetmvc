using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.CacheRepository
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = CacheDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                CacheDb.Orders.Remove(order);
            }
        }

        public List<Order> GetAll()
        {
            return CacheDb.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return CacheDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            CacheDb.OrderId++;
            entity.Id = CacheDb.OrderId;
            CacheDb.Orders.Add(entity);

        }

        public void Update(Order entity)
        {
            Order order = CacheDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (order != null)
            {
                int indexOfRecord = CacheDb.Orders.IndexOf(order);
                CacheDb.Orders[indexOfRecord] = entity;
            }
        }
    }
}
