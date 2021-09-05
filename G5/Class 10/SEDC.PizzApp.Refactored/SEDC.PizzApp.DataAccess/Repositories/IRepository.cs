using System.Collections.Generic;

namespace SEDC.PizzApp.DataAccess.Repositories
{
   public interface IRepository<T>
   {
      // CRUD (Create, Read, Update, Delete) Methods
      T GetById(int id); // READ

      List<T> GetAll(); // READ

      int Insert(T entity); // CREATE

      void Update(T entity); // UPDATE

      void DeleteById(int id); // DELETE
   }
}