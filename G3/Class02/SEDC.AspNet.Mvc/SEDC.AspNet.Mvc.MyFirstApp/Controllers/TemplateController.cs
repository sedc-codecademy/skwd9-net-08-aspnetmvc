using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.AspNet.Mvc.MyFirstApp.Controllers
{
    public class TemplateController : Controller
    {
        // GET: TemplateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TemplateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TemplateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemplateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TemplateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TemplateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TemplateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TemplateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
