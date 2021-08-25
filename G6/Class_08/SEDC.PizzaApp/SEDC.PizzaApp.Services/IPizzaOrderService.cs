using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.Services
{
    public interface IPizzaOrderService
    {
        public void MakeNewOrder(Order order);
    }
}
