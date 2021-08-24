using SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Interfaces;
using SEDC.AspNet.Mvc.Class06.DomainLayer.Repositories;
using SEDC.AspNet.Mvc.Class06.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductDto GetProduct(int id)
        {
            var product = _productRepository.Get(id);

            var productDto = new ProductDto
            {
                Id = product.Id,
                DateOfManufacturing = product.DateOfManufacturing,
                Name = product.Name,
                Price = product.Price
            };

            return productDto;
        }
    }
}
