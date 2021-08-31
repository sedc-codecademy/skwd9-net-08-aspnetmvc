using SEDC.PizzaApp.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDDViewModel> GetUsersForDropdown();
    }
}
