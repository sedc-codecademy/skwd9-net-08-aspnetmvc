using Microsoft.AspNetCore.Mvc;
using SEDC.LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.LibraryApp.Controllers
{
    //[Route("Kniga/[Action]")]
    public class BookController : Controller
    {
        [HttpGet] //default http method
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ListBooks()
        {
            return RedirectToAction("Index"); //Book/Index
        }

        public IActionResult BackToPrivacy()
        {
            return RedirectToAction("Privacy", "Home"); //Home/Privacy
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }
        [Route("Json")]
        public IActionResult GetJsonBook()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "Zoki Poki"
            };
            return new JsonResult(book);
        }

        [Route("Detali/{id?}")]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            Book book = StaticDb.Books.FirstOrDefault(x => x.Id == id);
            if(book == null)
            {
                return new EmptyResult();
            }
            return View(book);
        }
    }
}
