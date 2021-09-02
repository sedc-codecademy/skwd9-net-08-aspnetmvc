using System.Collections.Generic;
using System.Linq;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.Services.Services
{
   public class UserService : IUserService
   {
      private IRepository<User> _userRepository;
      private IRepository<Feedback> _feedbackRepository;

      public UserService(
         IRepository<User> userRepository,
         IRepository<Feedback> feedbackRepository)
      {
         _userRepository = userRepository;
         _feedbackRepository = feedbackRepository;
      }

      public int AddNewUser(User user)
      {
         return _userRepository.Insert(user);
      }

      public List<Feedback> GetFeedback(int numberOfFeedbackUnits)
      {
         return _feedbackRepository.GetAll().GetRange(0, numberOfFeedbackUnits);
      }

      public string GetLastUserName()
      {
         return _userRepository.GetAll().LastOrDefault()?.FirstName;
      }

      public User GetUserById(int id)
      {
         return _userRepository.GetById(id);
      }

      public void GiveFeedback(Feedback feedback)
      {
         _feedbackRepository.Insert(feedback);
      }
   }
}