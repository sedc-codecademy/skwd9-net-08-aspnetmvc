using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Models.Mapper
{
    public static class UserMapper
    {
        public static UserViewModel UserToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
