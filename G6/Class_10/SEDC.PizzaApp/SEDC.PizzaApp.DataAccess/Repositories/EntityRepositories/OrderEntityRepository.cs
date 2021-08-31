using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories
{
    public class OrderEntityRepository : IRepository<Order>
    {
        public List<Order> GetAll()
        {
            return StaticDb.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id.Equals(id));
        }

        public int Insert(Order entity)
        {
            Order lastOrder = StaticDb.Orders.LastOrDefault();

            if (lastOrder == null)
            {
                entity.Id = 1;
            }
            else
            {
                entity.Id = lastOrder.Id + 1;
            }

            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order Order = StaticDb.Orders.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (Order != null)
            {
                Order.UserId = entity.UserId;
            }
        }

        public void DeleteById(int id)
        {
            Order Order = StaticDb.Orders.FirstOrDefault(x => x.Id.Equals(id));

            if (Order != null)
            {
                StaticDb.Orders.Remove(Order);
            }
        }
    }
}
