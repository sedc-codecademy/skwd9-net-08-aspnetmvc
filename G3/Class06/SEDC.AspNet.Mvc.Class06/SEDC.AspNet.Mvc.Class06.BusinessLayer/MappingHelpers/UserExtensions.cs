using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using SEDC.AspNet.Mvc.Class06.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.MappingHelpers
{
    public static class UserExtensions
    {
        public static UserDto Map(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Age = user.Age,
                FullName = user.FullName,
                Phone = user.Phone
            };
        }
    }
}
