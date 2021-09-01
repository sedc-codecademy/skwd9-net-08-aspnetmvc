using System.Collections.Generic;
using SEDC.PizzApp.Domain.Models;

namespace SEDC.PizzApp.Services.Services
{
   public interface IUserService
   {
      User GetUserById(int id);

      int AddNewUser(User user);

      string GetLastUserName();

      void GiveFeedback(Feedback feedback);

      List<Feedback> GetFeedback(int numberOfFeedbackUnits);
   }
}