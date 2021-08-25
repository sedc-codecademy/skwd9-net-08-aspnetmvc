using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // all specific User methods
        List<User> GetUsersByAge(int age);
    }
}
