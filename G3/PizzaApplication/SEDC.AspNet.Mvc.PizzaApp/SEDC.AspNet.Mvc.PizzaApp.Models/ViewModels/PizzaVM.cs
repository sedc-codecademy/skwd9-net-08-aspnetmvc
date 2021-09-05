using SEDC.AspNet.Mvc.PizzaApp.Domain.Enums;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels
{
    public class PizzaVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public PizzaSize Size { get; set; }

        public static PizzaVM Map(Pizza pizza)
        {
            return new PizzaVM
            {
                Id = pizza.Id,
                ImageUrl = $"/images/{pizza.Image}",
                Name = pizza.Name,
                Price = pizza.Price,
                Size = pizza.Size
            };
        }
    }
}
