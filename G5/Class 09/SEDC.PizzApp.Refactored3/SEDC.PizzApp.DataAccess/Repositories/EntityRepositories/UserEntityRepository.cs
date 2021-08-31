using SEDC.PizzApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzApp.DataAccess.Repositories.EntityRepositories
{
   public class UserEntityRepository : IRepository<User>
   {
      private PizzaDbContext _context;

      public UserEntityRepository(PizzaDbContext context)
      {
         _context = context;
      }

      public void DeleteById(int id)
      {
         var user = _context.Users.FirstOrDefault(u => u.Id == id);

         if (user != null)
         {
            _context.Users.Remove(user);
         }

         _context.SaveChanges();
      }

      public List<User> GetAll()
      {
         return _context.Users.ToList();
      }

      public User GetById(int id)
      {
         return _context.Users.FirstOrDefault(user => user.Id == id);
      }

      public int Insert(User entity)
      {
         _context.Users.Add(entity);

         return _context.SaveChanges();
      }

      public void Update(User entity)
      {
         var user = _context.Users.FirstOrDefault(u => u.Id == entity.Id);

         if (user != null)
         {
            user.Address = entity.Address;
            user.LastName = entity.LastName;
            user.FirstName = entity.FirstName;
            user.Phone = entity.Phone;

            if (entity.Orders != null)
            {
               user.Orders = entity.Orders;
            }

            _context.Users.Update(user);
         }
      }
   }
}