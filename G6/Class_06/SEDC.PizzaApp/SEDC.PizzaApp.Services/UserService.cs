using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Repositories.EntityRepositories;
using SEDC.PizzaApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Services
{
    public class UserService
    {
        private IRepository<User> _userRepository;

        public UserService()
        {
            StaticDb database = new StaticDb();
            _userRepository = new UserEntityRepository(database);
        }

        public int AddNewUser(User entity)
        {
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

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteById(id);
        }
    }
}
