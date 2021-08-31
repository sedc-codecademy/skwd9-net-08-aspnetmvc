using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories
{
    public class UserEntityRepository : IRepository<User>
    {
        private PizzaDbContext _db;

        public UserEntityRepository(PizzaDbContext db)
        {
            _db = db;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
