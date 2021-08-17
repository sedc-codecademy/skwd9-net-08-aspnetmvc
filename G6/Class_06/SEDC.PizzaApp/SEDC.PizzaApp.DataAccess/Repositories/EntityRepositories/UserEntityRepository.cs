using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories
{
    public class UserEntityRepository : IRepository<User>
    {
        private StaticDb _context;

        public UserEntityRepository(StaticDb context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Address = entity.Address;
                user.Username = entity.Username;
                user.Phone = entity.Phone;
            }
        }

        public void DeleteById(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id.Equals(id));

            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
    }
}
