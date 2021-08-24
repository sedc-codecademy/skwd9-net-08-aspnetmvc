using SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.Services
{
    public class UserTwoService : IUserService
    {
        public UserDto GetUser(int id)
        {
            return new UserDto
            {
                Id = 123,
                Age = 123,
                FullName = "1234",
                Phone = 1234567890
            };
        }
    }
}
