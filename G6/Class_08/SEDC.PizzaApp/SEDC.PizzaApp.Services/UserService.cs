using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services
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
            // Validation
            // Do not allow user to be added with the same username
            return _userRepository.Insert(entity);
        }

        public string GetLastUsername()
        {
            return _userRepository.GetAll().LastOrDefault().Username;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateExistingUser(User user)
        {
            // Do not allow user to be edit with the same username as another username
            _userRepository.Update(user);
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteById(id);
        }
    }
}
