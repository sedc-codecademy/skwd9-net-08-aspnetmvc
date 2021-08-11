using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PizzaName { get; set; }
        public string UserFullName { get; set; }
        public double Price { get; set; }
        public bool Delivered { get; set; }
    }
}
