using SEDC.PizzApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzApp.DataAccess.Repositories.CacheRepositories
{
   public class UserRepository : IRepository<User>
   {
      public void DeleteById(int id)
      {
         var user = CacheDb.Users.FirstOrDefault(u => u.Id == id);

         if (user != null)
         {
            CacheDb.Users.Remove(user);
         }
      }

      public List<User> GetAll()
      {
         return CacheDb.Users;
      }

      public User GetById(int id)
      {
         return CacheDb.Users.FirstOrDefault(user => user.Id == id);
      }

      public int Insert(User entity)
      {
         CacheDb.UserId++;

         entity.Id = CacheDb.UserId;

         CacheDb.Users.Add(entity);

         return entity.Id;
      }

      public void Update(User entity)
      {
         var user = CacheDb.Users.FirstOrDefault(u => u.Id == entity.Id);

         if (user != null)
         {
            var index = CacheDb.Users.IndexOf(entity);

            CacheDb.Users[index] = entity;
         }
      }
   }
}