using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallace.UI.Models;
using Wallace.Common.Models;
using Wallace.Common.Database;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace Wallace.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult EditProject(int projectId)
        {
            HttpContext.Session.SetString("projectId", projectId.ToString());
            return RedirectToAction("ProjectEditPage");
        }

        public IActionResult ProjectEditPage()
        {

            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();
            int currentid = int.Parse(HttpContext.Session.GetString("projectId"));
            foreach(Project p in projects)
            {
                if (p.id == currentid) current = p;
            }
            ProjectEditPageModel model = new ProjectEditPageModel(current);

            return View(model);

        }

        public IActionResult TeamsPage()
        {
            TeamsPageModel model = new TeamsPageModel();
            string info = "Teams are groups of people who work together.";
            ViewData["Information"] = info;
            List<Employee> group1 = new List<Employee>();
            group1.Add(new Employee("Ken", 8072922, 50000, 1));
            group1.Add(new Employee("Dan", 8081010, 44500, 2));
              
            List<Employee> group2 = new List<Employee>();
            group2.Add(new Employee("Dave", 6062282, 77800, 3));
            group2.Add(new Employee("Steve", 5052773, 33500, 4));
            model.teams.Add(new Team(group1, "Dev Team", 1));
            model.teams.Add(new Team(group2, "SQA Team", 2));
            return View(model);
        }

        public IActionResult EmployeesPage()
        {
            string info = "Employees are people who work for your company.";
            ViewData["Information"] = info;
            EmployeesPageModel model = new EmployeesPageModel();
            model.Employees.Add(new Employee("Ken", 8072922,50000,1));
            model.Employees.Add(new Employee("Dan", 8081010, 44500, 2));
            model.Employees.Add(new Employee("Dave", 6062282, 77800, 3));
            model.Employees.Add(new Employee("Steve", 5052773, 33500,4));

            return View(model);
        }
        
        public IActionResult Index()
        {
            IndexPageModel model = new IndexPageModel();
            DatabaseInterface database = new DatabaseInterface();

            model.Projects = database.getProjects();
            return View(model);
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
