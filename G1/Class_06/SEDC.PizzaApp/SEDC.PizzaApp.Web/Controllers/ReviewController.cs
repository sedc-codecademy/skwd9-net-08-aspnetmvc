using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: ReviewController
        [Route("reviews")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: ReviewController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ReviewController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review review)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Review review)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReviewController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Review review)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
