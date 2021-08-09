using Microsoft.AspNetCore.Mvc;
using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web.Controllers
{
    [Route("knigi")]
    public class BookController : Controller
    {
        // There is no IActionResult in .Net Framework. 
        // You must use the particular type of result on each action

        //public ViewResult Index1()
        //{
        //    return View();
        //}

        [Route("pocetna")]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BackToPrivacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }


        public IActionResult OneBook()
        {
            Book book = new Book
            {
                Id = 1,
                Title = "Harry Potter and the goblet of fire"
            };

            return new JsonResult(book);
            //return new JsonResult(new { Title = "Harry Potter and the goblet of fire"});
        }

        [Route("books")]
        public IActionResult ListOfBooks()
        {
            Book book1 = new Book
            {
                Id = 1,
                Title = "Harry Potter and the goblet of fire"
            };

            Book book2 = new Book
            {
                Id = 2,
                Title = "Lord of the rings"
            };

            List<Book> books = new List<Book> { book1, book2 };
            
            return new JsonResult(books);
            //return new JsonResult(new { Title = "Harry Potter and the goblet of fire"});
        }

        public IActionResult BackToHome()
        {
            // If you pass only one argument that is an Action name
            // It tries to redirect on that action which is asumed to be in the same controller

            // return RedirectToAction("ListOfBooks");


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        public IActionResult Details(int id, string name)
        {
            if(id > 0)
            {
                Book book = StaticDB.Books.SingleOrDefault(x => x.Id == id);
                return new JsonResult(book);
            }
            else
            {
                return new JsonResult(new { Message = "Not found", Code = 404});
            }
        }


    }
}
