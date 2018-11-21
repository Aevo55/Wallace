using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallace.UI.Models;

namespace Wallace.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult EmployeesPage()
        {
            string info = "Employees are people who work for your company.";
            ViewData["Information"] = info;
            EmployeesPageModel model = new EmployeesPageModel();
            model.Employees.Add("Ken");
            model.Employees.Add("Dave");
            model.Employees.Add("Dan");
            model.Employees.Add("Alex");

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
