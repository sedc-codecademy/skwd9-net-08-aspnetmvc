using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class UserRepository : IRepository<User>
    {
        public void DeleteById(int id)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception($"User with id {id} was not found");
            }
            StaticDb.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            entity.Id = ++StaticDb.UserId;
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception($"User with id {entity.Id} was not found");
            }
            int index = StaticDb.Users.IndexOf(user);
            StaticDb.Users[index] = entity;
        }
    }
}
