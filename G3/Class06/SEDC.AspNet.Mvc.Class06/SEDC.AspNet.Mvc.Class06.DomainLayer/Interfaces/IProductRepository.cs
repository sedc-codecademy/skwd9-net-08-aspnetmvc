using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // all specific product methods
        List<Product> GetProductsByPrice(int price);
    }
}
