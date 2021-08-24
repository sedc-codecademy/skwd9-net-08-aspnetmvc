using SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.BusinessLayer.MappingHelpers;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Repositories;
using SEDC.AspNet.Mvc.Class06.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // without DI
        //public UserService()
        //{
        //    _userRepository = new UserRepository();
        //}

        public UserDto GetUser(int id)
        {
            var user = _userRepository.Get(id);

            var userDto = user.Map();

            return userDto;
        }
    }
}
