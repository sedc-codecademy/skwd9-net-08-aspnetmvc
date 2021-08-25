using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
