using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SEDC.DbDemo.DataAccess;
using SEDC.DbDemo.Domain;
using SEDC.DbDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.DbDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // This is something that you should NEVER do!!! Use only for demo purpose!

        private CompanyDbContext _db;

        public HomeController(ILogger<HomeController> logger, CompanyDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Company> companies = _db.Companies.Include(x => x.Employees).ToList();
            Employee employee = new Employee { FirstName = "Filip", LastName = "Janev", CompanyId = 2, YearsOfExperience = 3 };

            _db.Employees.Add(employee);
            _db.Companies.Add(new Company() { Name = "Iborn", Location = "Skopje", NumberOfEmployees = 60, Employees = new List<Employee> { employee } });

            _db.SaveChanges();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
