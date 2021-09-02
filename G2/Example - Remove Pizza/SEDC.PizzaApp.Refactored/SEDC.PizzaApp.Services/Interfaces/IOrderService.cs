﻿using SEDC.PizzaApp.ViewModels.OrderViewModels;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;
using System.Collections.Generic;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel);
        OrderViewModel GetOrderForEditing(int id);
        void EditOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int id);
        List<PizzaDDViewModel> GetPizzasForRemoveDropdown(int orderId);
        void RemovePizzaFromOrder(RemovePizzaModel removePizzaModel);
    }
}
