using System.Collections.Generic;

namespace SEDC.PizzaApp.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
