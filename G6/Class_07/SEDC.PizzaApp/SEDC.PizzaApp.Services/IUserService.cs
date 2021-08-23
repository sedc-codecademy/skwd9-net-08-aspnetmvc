using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services
{
    public interface IUserService
    {
        public int AddNewUser(User entity);

        public string GetLastUsername();

        public List<User> GetAllUsers();

        public User GetUserById(int id);

        public void UpdateExistingUser(User user);

        public void DeleteUserById(int id);
    }
}
