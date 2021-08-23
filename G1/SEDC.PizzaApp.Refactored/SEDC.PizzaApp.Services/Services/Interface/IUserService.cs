using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Services.Interface
{
    public interface IUserService
    {
        List<User> GetUsers();
        int AddNewUser(User entity);
        string GetLastUserName();
    }
}
