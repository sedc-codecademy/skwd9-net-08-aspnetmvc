using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;

namespace SEDC.AspNet.Mvc.PizzaApp.Models.ServiceResponse
{
    public class CreateOrderServiceResponse
    {
        public string ErrorMessage { get; set; }
        public CreateOrderVM Order { get; set; }
        public bool IsSuccess { get; set; }
    }
}
