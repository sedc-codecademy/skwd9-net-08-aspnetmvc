using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EfRepositories
{
    public class OrderEfRepository : IRepository<Order>
    {
        private readonly PizzaDbContext _dbContext;

        public OrderEfRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            Order order = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if(order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.User)
                .ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.User)
                .FirstOrDefault(x => x.OrderId == id);
        }

        public int Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            int id = _dbContext.SaveChanges();
            return id;
        }

        public void Update(Order entity)
        {
            Order order = _dbContext.Orders.FirstOrDefault(x => x.OrderId == entity.OrderId);
            if(order != null)
            {
                order.DeliveryPrice = entity.DeliveryPrice;
                order.IsDelivered = entity.IsDelivered;
                order.PizzaOrders = entity.PizzaOrders;
                order.User = entity.User;
                _dbContext.Orders.Update(order);
                _dbContext.SaveChanges();
            }
        }
    }
}
