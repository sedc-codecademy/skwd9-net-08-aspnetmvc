using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddNewUser(User entity)
        {
            return _userRepository.Insert(entity);
        }

        public string GetLastUserName()
        {
            //return _userRepository.GetAll().LastOrDefault() != null ?
            //        _userRepository.GetAll().LastOrDefault().FirstName :
            //        null;

            return _userRepository.GetAll().LastOrDefault()?.FirstName;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
