using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.CacheRepository
{
    public class UserRepository : IRepository<User>
    {
        public void DeleteById(int id)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                CacheDb.Users.Remove(user);
            }
        }

        public List<User> GetAll()
        {
            return CacheDb.Users;
        }

        //implementation with inline function
        //public List<User> GetAll() => CacheDb.Users;

        public User GetById(int id)
        {
            //check if we have some record or not will be made on the bussiness layer or presentation layer
            //also the check for if id is valid will be made on bussiness layer or presentation layer
            //User user = CacheDb.Users.FirstOrDefault(x => x.Id == id);
            //if (user == null)
            //{
            //    return null;
            //}
            //return user;
            return CacheDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(User entity)
        {
            CacheDb.UserId++;
            entity.Id = CacheDb.UserId;
            CacheDb.Users.Add(entity);
        }

        public void Update(User entity)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                //first way of update for record(we can use this because we use lists)
                int indexOfUser = CacheDb.Users.IndexOf(user);
                CacheDb.Users[indexOfUser] = entity;

                //seconed way of updating record(if we use real db or in-memory db)
                //user.FirstName = entity.FirstName;
                //user.LastName = entity.LastName;
                //entity.Address = entity.Address;
                //entity.Phone = entity.Phone;
            }
        }
    }
}
