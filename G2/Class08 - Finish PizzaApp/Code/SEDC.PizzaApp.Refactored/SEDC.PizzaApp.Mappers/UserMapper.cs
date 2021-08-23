using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.UserViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class UserMapper
    {
        public static UserDDViewModel ToUserDDViewModel(this User user)
        {
            return new UserDDViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
