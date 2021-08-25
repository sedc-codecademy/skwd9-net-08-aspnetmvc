using SEDC.AspNet.Mvc.Class06.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();

        // CRUD operations
        // All common methods
    }
}
