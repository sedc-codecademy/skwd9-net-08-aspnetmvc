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
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
