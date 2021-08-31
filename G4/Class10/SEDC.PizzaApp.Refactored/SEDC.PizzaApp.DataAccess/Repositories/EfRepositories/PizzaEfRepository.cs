using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EfRepositories
{
    public class PizzaEfRepository : IRepository<Pizza>
    {
        private readonly PizzaDbContext _dbContext;

        public PizzaEfRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
