using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Services.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
        List<Order> GetAll();
    }
}
