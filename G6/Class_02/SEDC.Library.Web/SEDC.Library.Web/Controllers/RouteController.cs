using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web.Controllers
{
    //[Route("main")]
    [Route("knigi")]
    //[Route("Route/Index")]
    public class RouteController : Controller
    {
        [Route("glavna-strana")]
        public IActionResult Index()
        {
            return new JsonResult(new { Message = "Test routing"});
        }
    }
}
