using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Models;
using System.Data.SqlClient;
using Wallace.Common.Database;
namespace Wallace.Common.Database
{
    public class DatabaseInterface
    {
        DatabaseReader client;
        public DatabaseInterface() {
            client = new DatabaseReader();
        }

        public List<Project> getProjects()
        {
            List<Project> projects = new List<Project>();
            foreach(DBProject p in client.getProjects())
            {
                Project _p = new Project(p);
                foreach(DBVersion v in client.getVersions(p))
                {
                    PVersion _v = new PVersion(v);
                    foreach(DBSpecification s in client.getSpecs(v))
                    {
                        _v.specs.Add(new Spec(s));
                    }
                    _p.versions.Add(_v);
                }
                foreach(DBSpecification s in client.getSpecs(p))
                {
                    _p.specs.Add(new Spec(s));
                }
                projects.Add(_p);
            }
            return projects;
        }

        public List<Team> getTeams()
        {
            List<Team> teams = new List<Team>();
            foreach(DBTeam t in client.getTeams())
            {
                Team _t = new Team(t);
                foreach(DBEmployee e in client.getEmployees(t))
                {
                    _t.members.Add(new Employee(e));
                }
                teams.Add(_t);
            }
            return teams;
        }

        public List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            foreach(DBEmployee e in client.getEmployees())
            {
                Employee _e = new Employee(e);
                foreach(DBTeam t in client.getTeams(e))
                {
                    _e.teams.Add(new Team(t));
                }
                employees.Add(_e);
            }
            return employees;
        }
    }
}
