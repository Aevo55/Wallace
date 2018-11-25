﻿using System;
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
