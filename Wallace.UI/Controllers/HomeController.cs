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

        
        public IActionResult SubmitVersion(int _versionNumber, DateTime _releaseDate, string[] _specs, string[] _teams, int _id, int _pid, int _vid)
        {
            

            DatabaseInterface database = new DatabaseInterface();
            PVersion newversion = new PVersion();
            if(_id == -1)
            {
                newversion.versionNumber = _versionNumber;
                newversion.releaseDate = _releaseDate;
                newversion.pid = _pid;

                int newid = database.addVersion(newversion);
                newversion.id = newid;
                foreach(string s in _specs)
                {

                    //List<Spec> allspecs = database.getProjects().Find(x => x.id ==_pid).specs;
                    //Spec spectoadd = allspecs.Find(x => x.id == int.Parse(s));
                    Spec spectoadd = database.getSpec(int.Parse(s));
                    database.addSpecToVersion(newversion, spectoadd);
                }

                foreach (string t in _teams)
                {
                    //List<Team> allteams = database.getTeams();
                    //Team teamtoadd = allteams.Find(x => x.id == int.Parse(t));
                    Team teamtoadd = database.getTeam(int.Parse(t));
                    database.addTeamToVersion(teamtoadd,newversion);
                }

            }
            else if(_id != -1)
            {
                newversion.versionNumber = _versionNumber;
                newversion.releaseDate = _releaseDate;
                newversion.pid = _pid;
                newversion.id = _vid;
                database.updateVersion(newversion);
                
                foreach (string s in _specs)
                {

                    //List<Spec> allspecs = database.getProjects().Find(x => x.id == _pid).specs;
                    //List<Spec> allspecs = database.getSpecsByProject(_pid);
                    //Spec spectoadd = allspecs.Find(x => x.id == int.Parse(s));
                    /*
                     sss
                     sss
                     sss
                     */

                    ///sdsdeedede
                    Spec spectoadd = database.getSpec(int.Parse(s));
                    database.addSpecToVersion(newversion, spectoadd);
                }
                foreach (string t in _teams)
                {
                    //List<Team> allteams = database.getTeams();
                    //Team teamtoadd = allteams.Find(x => x.id == int.Parse(t));
                    Team teamtoadd = database.getTeam(int.Parse(t));
                    database.addTeamToVersion(teamtoadd, newversion);
                }
            }
            

            return RedirectToAction("ProjectEditPage", new { projectId = _pid});
        }

        public IActionResult SubmitNewProject(string _name, int _budget,string _desc, int _manager)
        {
            Project newproject = new Project();
            newproject.name = _name;
            newproject.budget = _budget;
            newproject.desc = _desc;
            DatabaseInterface database = new DatabaseInterface();
            List<Employee> employees = database.getEmployees();
            foreach (Employee e in employees)// add the employees from the array into the team
            {
                if (_manager == e.id)
                {
                    newproject.manager = e;
                }
            }

            database.addProject(newproject);
            return RedirectToAction("Index");
        }

        public IActionResult SubmitEmployee(string _name, int _salary, string _title, int _employeeId)
        {

            DatabaseInterface database = new DatabaseInterface();

            if (_employeeId != -1)
            {
                Employee newemp = new Employee(_name, _title, _salary, _employeeId);
                database.updateEmployee(newemp);
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

            if (teamId == -1)
            {
                model.isNew = true;
                current.id = -1;
            }
            else
            {
                model.isNew = false;

                foreach (Team t in teams)
                {
                    if (t.id == teamId) current = t;
                }
            }
            
            model.team = current;

            List<Employee> _employees = database.getEmployees();
            model.employees = _employees;

            ViewData["Information"] = "This is where you can edit a team";
            return View(model);
        }

        public IActionResult SubmitTeam(string _name, string _desc, int _id, string[] _employees)
        {
            DatabaseInterface database = new DatabaseInterface();
            List<Employee> employees = database.getEmployees();
            List<String> strings;
            if(_id == -1)
            {
                Team newteam = new Team();
                newteam.name = _name;
                newteam.desc = _desc;
                int newid = database.addTeam(newteam);
                newteam.id = newid;
                foreach (Employee e in employees)// add the employees from the array into the team
                {
                    foreach(string s in _employees)
                    {
                        if (int.Parse(s) == e.id)
                        {
                            database.addEmpToTeam(e, newteam); 
                        }
                    }
                }

            }
            if(_id != -1)
            {
                List<Team> teams = database.getTeams();
                Team current = new Team();
                foreach(Team t in teams)
                {
                    if (t.id == _id) current = t;
                }

                foreach(string s in _employees)
                {
                    bool isin = false;
                    foreach(Employee e in current.members)
                    {
                        if (int.Parse(s) == e.id) isin = true;
                    }
                    if (!isin)
                    {
                        Employee newmember = new Employee();
                        List<Employee> allemployees = database.getEmployees();
                        foreach(Employee e in allemployees)
                        {
                            if(e.id == int.Parse(s))
                            {
                                newmember = e;
                            }
                        }
                        database.addEmpToTeam(newmember, current);
                    }
                }

                current.name = _name;
                current.desc = _desc;

            }



            return RedirectToAction("TeamsPage");
        }

        public IActionResult RemoveTeamMember(int _empId, int _teamId)
        {
            DatabaseInterface database = new DatabaseInterface();
            database.deleteEmployeeFromTeam(_teamId, _empId);
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
            if (!model.isNew)
            {
                foreach (Employee e in employees)
                {
                    if (e.id == employeeId) current = e;
                }
                model.employee = current;
            }
            if (model.isNew)
            {
                current.id = -1;
            }
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

        public IActionResult DeleteProject(int projectId)
        {
            DatabaseInterface database = new DatabaseInterface();
            database.deleteProject(projectId);
            return RedirectToAction("CurrentProject");
        }

        public IActionResult DeleteVersion(int _projectId, int _versionId)
        {
            DatabaseInterface database = new DatabaseInterface();
            database.deleteVersion(_versionId);
            return RedirectToAction("ProjectEditPage", new { projectId = _projectId });
        }

        public IActionResult ProjectEditPage(int projectId)
        {

            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();
            if (projectId != -1)
            {
                foreach (Project p in projects)
                {
                    if (p.id == projectId) current = p;
                }
            }
            
            ProjectEditPageModel model = new ProjectEditPageModel(current);
            
            return View(model);

        }

        public IActionResult AddSpecToProject(int _pid, string _name, string _description)
        {
            DatabaseInterface database = new DatabaseInterface();
            Spec newspec = new Spec();
            newspec.name = _name;
            newspec.description = _description;
            newspec.pid = _pid;
            database.addSpecToProject(newspec);
            return RedirectToAction("ProjectEditPage", new { projectId = _pid});
        }

        public IActionResult ProjectViewPage(int projectId)
        {

            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();
            if (projectId != -1)
            {
                foreach (Project p in projects)
                {
                    if (p.id == projectId) current = p;
                }
            }

            ProjectViewPageModel model = new ProjectViewPageModel(current);

            return View(model);

        }

        public IActionResult NewProjectEditPage()
        {
            NewProjectEditPageModel model = new NewProjectEditPageModel();
            DatabaseInterface database = new DatabaseInterface();
            model.employees = database.getEmployees();
            return View(model);
        }

        public IActionResult VersionEditPage(int projectId, int versionId)
        {
            DatabaseInterface database = new DatabaseInterface();
            List<Project> projects = database.getProjects();
            Project current = new Project();

            current = database.getProject(projectId);

            PVersion currentversion = new PVersion();

            VersionEditPageModel model = new VersionEditPageModel();

            if (versionId == -1)
            {
                model.isNew = true;
                currentversion.id = -1;
                model.minVersionNumber = database.getMaxVersionNum(projectId) + 1;
            }

            else if(versionId != -1)
            {
                model.isNew = false;
                currentversion = database.getVersion(versionId);
            }

            model.pid = projectId;
            model.version = currentversion;
            model.projectSpecifications = current.specs;

            foreach (Spec s in database.getUnmetSpecs(versionId, projectId))
            {
                model.NotMetSpecs.Add(s);
            }

            foreach (Team t in database.getTeamsNotOnVer(versionId))
            {
                model.TeamsNotWorking.Add(t);
            }

            return View(model);
        }

        public IActionResult VersionViewPage(int projectId, int versionId)
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
            foreach (PVersion v in current.versions)
            {
                if (v.id == versionId) currentversion = v;
            }
            VersionViewPageModel model = new VersionViewPageModel();

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

        public IActionResult EmployeesPage(string query)
        {

            EmployeesPageModel model = new EmployeesPageModel();
            DatabaseInterface database = new DatabaseInterface();
            string info = "Employees are people who work for your company.";
            ViewData["Information"] = info;
            ViewData["Query"] = query ?? null;
            List<Employee> employees = new List<Employee>();
            if(query != null)
            {
                employees = database.searchEmployees(query);
            }
            else
            {
                employees = database.getEmployees();
            }
            model.Employees = employees;
            return View(model);
        }

        public IActionResult CurrentProject()
        {
            IndexPageModel model = new IndexPageModel();
            DatabaseInterface database = new DatabaseInterface();

            model.Projects = database.getProjects();
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
