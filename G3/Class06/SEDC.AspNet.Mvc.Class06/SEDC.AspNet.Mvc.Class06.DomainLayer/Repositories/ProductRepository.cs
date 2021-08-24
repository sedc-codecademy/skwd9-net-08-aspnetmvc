using SEDC.AspNet.Mvc.Class06.DomainLayer.Database;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.DomainLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            return InMemoryDb.Products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return InMemoryDb.Products;
        }

        public List<Product> GetProductsByPrice(int price)
        {
            throw new NotImplementedException();
        }
    }
}
