using Microsoft.AspNetCore.Mvc;
using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web.Controllers
{
    public class PublishingHouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            PublishingHouse publishingHouse = StaticDB.PublishingHouses.SingleOrDefault(q => q.Id.Equals(id));

            return View(publishingHouse);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
