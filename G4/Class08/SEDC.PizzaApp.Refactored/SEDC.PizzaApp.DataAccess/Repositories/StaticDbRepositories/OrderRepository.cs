using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            var order = StaticDb.Orders.FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        public int Insert(Order entity)
        {
            var orderId = StaticDb.Orders.Max(x => x.OrderId) + 1;
            entity.OrderId = orderId;
            StaticDb.Orders.Add(entity);
            return orderId;
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
