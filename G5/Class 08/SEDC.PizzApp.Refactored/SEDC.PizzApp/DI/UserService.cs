using System.Collections.Generic;
using SEDC.PizzApp.Models;

namespace SEDC.PizzApp.DI
{
   public class UserService : IUserService
   {
      public List<User> GetAllUsers()
      {
         return new List<User>();
         //return Db.Users;
      }

      public User GetUserById(int id)
      {
         return new User();
         //return Db.Users.FirstOrDefault(x => x.Id == id);
      }
   }
}