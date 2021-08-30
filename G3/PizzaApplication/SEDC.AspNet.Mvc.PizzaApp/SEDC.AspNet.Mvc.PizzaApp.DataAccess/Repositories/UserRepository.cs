using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly PizzaContext _context;

        public UserRepository(PizzaContext pizzaContext)
        {
            _context = pizzaContext;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public List<User> GetByFilter(Func<User, bool> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == entity.Id);
            if(user != null)
            {
                user.Address = entity.Address;
                user.LastName = entity.LastName;
                user.FirstName = entity.FirstName;
                user.Phone = entity.Phone;
                if(entity.Orders != null)
                {
                    user.Orders = entity.Orders;
                }
            }
            _context.SaveChanges();
        }
    }
}
