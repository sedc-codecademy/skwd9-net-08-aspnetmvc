using SEDC.AspNet.Mvc.PizzaApp.Models.ServiceResponse;
using SEDC.AspNet.Mvc.PizzaApp.Models.ViewModels;

namespace SEDC.AspNet.Mvc.PizzaApp.BusinessLayer.Interfaces
{
    public interface IPizzaOrderService
    {
        OrderVM GetOrders();
        CreateOrderServiceResponse CreateOrder(CreateOrderVM request);
    }
}
