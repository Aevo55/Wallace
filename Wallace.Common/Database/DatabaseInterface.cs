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
        DatabaseReader reader;
        DatabaseWriter writer;
        public DatabaseInterface() {
            reader = new DatabaseReader();
            writer = new DatabaseWriter();
        }

        public List<Project> getProjects()
        {
            List<Project> projects = new List<Project>();
            foreach(DBProject p in reader.getProjects())
            {
                Project _p = new Project(p);
                foreach(DBVersion v in reader.getVersions(p))
                {
                    PVersion _v = new PVersion(v);
                    foreach(DBSpecification s in reader.getSpecs(v))
                    {
                        _v.specs.Add(new Spec(s));
                    }
                    _p.versions.Add(_v);
                }
                foreach(DBSpecification s in reader.getSpecs(p))
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
            foreach(DBTeam t in reader.getTeams())
            {
                Team _t = new Team(t);
                foreach(DBEmployee e in reader.getEmployees(t))
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
            foreach(DBEmployee e in reader.getEmployees())
            {
                Employee _e = new Employee(e);
                foreach(DBTeam t in reader.getTeams(e))
                {
                    _e.teams.Add(new Team(t));
                }
                employees.Add(_e);
            }
            return employees;
        }
    }
}
