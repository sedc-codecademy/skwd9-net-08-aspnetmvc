using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public OrderRepository()
        {

        }
        public void DeleteById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Orders.IndexOf(orderDb);
            StaticDb.Orders[index] = entity;
        }
    }
}
