using System.Collections.Generic;
using SEDC.PizzApp.Models;

namespace SEDC.PizzApp.DI
{
   public interface IUserService
   {
      List<User> GetAllUsers();

      User GetUserById(int id);
   }
}