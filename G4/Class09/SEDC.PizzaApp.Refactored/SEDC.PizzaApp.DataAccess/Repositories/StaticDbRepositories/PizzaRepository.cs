using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            return StaticDb.Menu;
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
