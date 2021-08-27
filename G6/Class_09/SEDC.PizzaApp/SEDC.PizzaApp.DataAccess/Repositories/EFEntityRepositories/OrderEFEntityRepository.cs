using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.EFEntityRepositories
{
    public class OrderEFEntityRepository : IRepository<Order>
    {
        private PizzaDbContext _pizzaDbContext;

        public OrderEFEntityRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public List<Order> GetAll()
        {
            return _pizzaDbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _pizzaDbContext.Orders.FirstOrDefault(x => x.Id.Equals(id));
        }

        public int Insert(Order entity)
        {
            _pizzaDbContext.Orders.Add(entity);
            _pizzaDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order Order = _pizzaDbContext.Orders.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (Order != null)
            {
                Order.UserId = entity.UserId;
            }

            _pizzaDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Order Order = _pizzaDbContext.Orders.FirstOrDefault(x => x.Id.Equals(id));

            if (Order != null)
            {
                _pizzaDbContext.Orders.Remove(Order);
            }

            _pizzaDbContext.SaveChanges();
        }
    }
}
