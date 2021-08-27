using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.EFEntityRepositories
{
    public class UserEFEntityRepository : IRepository<User>
    {
        private PizzaDbContext _pizzaDbContext;

        public UserEFEntityRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public List<User> GetAll()
        {
            return _pizzaDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _pizzaDbContext.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public int Insert(User entity)
        {
            _pizzaDbContext.Users.Add(entity);
            _pizzaDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = _pizzaDbContext.Users.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Address = entity.Address;
                user.Username = entity.Username;
                user.Phone = entity.Phone;
            }

            _pizzaDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            User user = _pizzaDbContext.Users.FirstOrDefault(x => x.Id.Equals(id));

            if (user != null)
            {
                _pizzaDbContext.Users.Remove(user);
            }

            _pizzaDbContext.SaveChanges();
        }
    }
}
