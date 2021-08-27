using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        // CRUD (create, read, update, delete) methods
        T GetById(int id);
        List<T> GetAll();
        List<T> GetByFilter(Func<T, bool> filter);
        int Insert(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
