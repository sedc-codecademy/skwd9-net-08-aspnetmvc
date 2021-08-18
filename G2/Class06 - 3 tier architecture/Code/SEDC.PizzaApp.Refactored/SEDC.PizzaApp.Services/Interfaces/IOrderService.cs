using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
    }
}
