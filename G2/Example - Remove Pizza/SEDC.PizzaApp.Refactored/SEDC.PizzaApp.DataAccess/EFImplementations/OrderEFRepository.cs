using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Shared.CustomExceptions;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            _pizzaAppDbContext.Orders.Remove(orderDb); // no db call
            _pizzaAppDbContext.SaveChanges(); // db call
        }

        public List<Order> GetAll()
        {
            //select* from Orders o
            //inner join PizzaOrder po
            //on o.Id = po.OrderId
            //inner join Pizzas p
            //on po.PizzaId = p.Id
            //inner join Users u
            //on u.Id = o.UserId

            return _pizzaAppDbContext.Orders //access to table Orders (select* from Orders o)
                    .Include(x => x.PizzaOrders)//join with PizzaOrder
                    .ThenInclude(x => x.Pizza) // join between PizzaOrder and Pizzas tables
                    .Include(x => x.User)  //join Users
                    .ToList();
        }

        public Order GetById(int id)
        {
            return _pizzaAppDbContext.Orders //access to table Orders (select* from Orders o)
                   .Include(x => x.PizzaOrders) //join with PizzaOrder
                   .ThenInclude(x => x.Pizza) // join between PizzaOrder and Pizzas tables
                   .Include(x => x.User) //join Users
                   .FirstOrDefault(x => x.Id == id); // where clause
        }

        public int Insert(Order entity)
        {
            _pizzaAppDbContext.Orders.Add(entity); // no db call
            return _pizzaAppDbContext.SaveChanges(); //db call
        }

        public void Update(Order entity)
        {
            _pizzaAppDbContext.Orders.Update(entity); //no db call
            _pizzaAppDbContext.SaveChanges();

        }
    }
}
