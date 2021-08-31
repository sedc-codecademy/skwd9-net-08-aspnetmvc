using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDDViewModel ToPizzaDDViewModel(this Pizza pizza)
        {
            return new PizzaDDViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name
            };
        }
    }
}
