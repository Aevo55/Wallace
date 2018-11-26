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

        public IActionResult SubmitEmployee(string _name, int _salary, string _title, int _employeeId)
        {

            DatabaseInterface database = new DatabaseInterface();

            if (_employeeId != -1)
            {
                Employee newemp = new Employee(_name, _title, _salary, _employeeId);
                //database modify employee
            }
            if(_employeeId == -1)
            {
                Employee newemp = new Employee(_name, _title, _salary);
                database.addEmployee(newemp);
            }

            return RedirectToAction("EmployeesPage");

        }

        public IActionResult TeamEditPage(int teamId)
        {
            TeamEditPageModel model = new TeamEditPageModel();
            DatabaseInterface database = new DatabaseInterface();
            List<Team> teams = database.getTeams();
            Team current = new Team();
            foreach(Team t in teams)
            {
                if (t.id == teamId) current = t;
            }
            model.team = current;
            if (teamId == -1)
            {
                model.isNew = true;
            }
            else model.isNew = false;
            ViewData["Information"] = "This is where you can edit a team";
            return View(model);
        }

        public IActionResult SubmitTeam(string _name, string _desc, int _id)
        {
            return RedirectToAction("TeamsPage");
        }

        public IActionResult EditEmployeePage(int employeeId)
        {
            EmployeeEditPageModel model = new EmployeeEditPageModel();
            if (employeeId == -1) { model.isNew = true; }
            else model.isNew = false;

            DatabaseInterface database = new DatabaseInterface();
            List<Employee> employees = database.getEmployees();
            Employee current = new Employee();
            foreach(Employee e in employees)
            {
                if (e.id == employeeId) current = e;
            }
            model.employee = current;
            ViewData["Information"] = "This is where you can edit an employee's record";

            return View(model);

        }

        public IActionResult DeleteEmployee(int employeeId)
        {
            DatabaseInterface database = new DatabaseInterface();
            database.deleteEmployee(employeeId);
            return RedirectToAction("EmployeesPage");
        }

        public IActionResult DeleteTeam(int teamId)
        {
            DatabaseInterface database = new DatabaseInterface();
            database.deleteTeam(teamId);
            return RedirectToAction("TeamsPage");
        }

        public IActionResult ProjectEditPage(int projectId)
        {

            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();
            int currentid = projectId;
            foreach (Project p in projects)
            {
                if (p.id == currentid) current = p;
            }
            ProjectEditPageModel model = new ProjectEditPageModel(current);

            return View(model);

        }

        public IActionResult VersionEditPage(int projectId, int versionId)
        {
            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();
            int currentid = projectId;
            foreach (Project p in projects)
            {
                if (p.id == currentid) current = p;
            }
            PVersion currentversion = new PVersion(); 
            foreach(PVersion v in current.versions)
            {
                if (v.id == versionId) currentversion = v;
            }
            VersionEditPageModel model = new VersionEditPageModel();
            model.version = currentversion;

            return View(model);
        }

        public IActionResult TeamsPage()
        {
            TeamsPageModel model = new TeamsPageModel();

            DatabaseInterface database = new DatabaseInterface();
            string info = "Teams are groups of people who work together.";
            ViewData["Information"] = info;

            List<Team> teams = new List<Team>();
            teams = database.getTeams();
            model.teams = teams;
            return View(model);
        }

        public IActionResult EmployeesPage()
        {
            string info = "Employees are people who work for your company.";
            ViewData["Information"] = info;
            EmployeesPageModel model = new EmployeesPageModel();
            DatabaseInterface database = new DatabaseInterface();
            List<Employee> employees = new List<Employee>();
            employees = database.getEmployees();
            model.Employees = employees;
            return View(model);
        }
        
        public IActionResult Index()
        {
            IndexPageModel model = new IndexPageModel();
            DatabaseInterface database = new DatabaseInterface();

            model.Projects = database.getProjects();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
