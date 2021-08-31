using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories
{
    public class OrderEntityRepository : IRepository<Order>
    {
        private PizzaDbContext _db;
        public OrderEntityRepository(PizzaDbContext db)
        {
            _db = db;
        }

        public void DeleteById(int id)
        {
            Order order = _db.Orders.SingleOrDefault(x => x.Id == id);
            if(order != null)
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _db.Orders
                      .Include(x => x.PizzaOrders)
                      .ThenInclude(x => x.Pizza)
                      .Include(x => x.User)
                      .ToList();
        }

        public Order GetById(int id)
        {
            return _db.Orders.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            _db.Orders.Add(entity);
            int id = _db.SaveChanges();
            return id;
        }

        public void Update(Order entity)
        {
            Order order = _db.Orders.SingleOrDefault(x => x.Id == entity.Id);
            if(order != null)
            {
                entity.Id = order.Id;
                _db.Orders.Update(entity);
            }
        }
    }
}
