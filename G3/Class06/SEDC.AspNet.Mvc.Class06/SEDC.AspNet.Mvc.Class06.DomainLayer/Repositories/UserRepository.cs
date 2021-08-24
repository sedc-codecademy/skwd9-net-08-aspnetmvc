using SEDC.AspNet.Mvc.Class06.DomainLayer.Database;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            return InMemoryDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return InMemoryDb.Users;
        }

        public List<User> GetUsersByAge(int age)
        {
            throw new NotImplementedException();
        }
    }
}
