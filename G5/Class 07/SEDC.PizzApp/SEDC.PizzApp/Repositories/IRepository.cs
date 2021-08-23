using System.Collections.Generic;

namespace SEDC.PizzApp.Repositories
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