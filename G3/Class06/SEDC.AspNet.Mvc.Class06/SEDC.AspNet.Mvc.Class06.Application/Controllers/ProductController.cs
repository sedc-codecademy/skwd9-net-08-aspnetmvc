using Microsoft.AspNetCore.Mvc;
using SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class06.Application.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var response = _productService.GetProduct(id);
            return Json(response);
        }
    }
}
