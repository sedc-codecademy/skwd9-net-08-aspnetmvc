using Microsoft.AspNetCore.Mvc;
using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web.Controllers
{
    //[Route("books")]
    public class BookController : Controller
    {
        // This is how an action that returns a View looks like in .NET Framework
        //public ViewResult Index()
        //{
        //    return View();
        //}


        // This applies for .NET Core
        public IActionResult Index()
        {
            return View();
        }

        // An action that returns an EmptyResult and does not need a View
        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        public IActionResult JsonData()
        {
            Book book = new Book
            {
                Id = 1,
                Title = "Harry Potter"
            };
            return new JsonResult(book);
        }

        public IActionResult ListOfBooks()
        {
            Book book1 = new Book
            {
                Id = 1,
                Title = "Harry Potter 1"
            };
            Book book2 = new Book
            {
                Id = 2,
                Title = "Harry Potter 2"
            };

            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            return new JsonResult(books);
        }


        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult Details(int id)
        {
            Book book = StaticDB.Books.Where(x => x.Id == id).SingleOrDefault();

            //if(book == null)
            //{
            //    return RedirectToAction("Error", "Home");
            //}
            return View(book);
        }

    }
}
