using SEDC.AspNet.Mvc.Class06.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.AspNet.Mvc.Class06.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        ProductDto GetProduct(int id);
    }
}
