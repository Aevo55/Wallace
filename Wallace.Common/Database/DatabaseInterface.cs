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
        DatabaseDeleter deleter;
        public DatabaseInterface() {
            reader = new DatabaseReader();
            deleter = new DatabaseDeleter();
        }

        public List<Project> getProjects()
        {
            List<Project> projects = new List<Project>();
            foreach(DBProject p in reader.getAllProjects())
            {
                Project _p = new Project(p);
                foreach(DBVersion v in reader.getVersionsByProj(p.id))
                {
                    PVersion _v = new PVersion(v);
                    foreach(DBSpecification s in reader.getSpecsByVer(v.id))
                    {
                        _v.specs.Add(new Spec(s));
                    }
                    _p.versions.Add(_v);
                }
                foreach(DBSpecification s in reader.getSpecsByVer(p.id))
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
            foreach(DBTeam t in reader.getAllTeams())
            {
                Team _t = new Team(t);
                foreach(DBEmployee e in reader.getEmpsByTeam(t.id))
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
            foreach(DBEmployee e in reader.getAllEmployees())
            {
                Employee _e = new Employee(e);
                foreach(DBTeam t in reader.getTeamsByEmp(e.id))
                {
                    _e.teams.Add(new Team(t));
                }
                employees.Add(_e);
            }
            return employees;
        }

        public void deleteProject(int id)
        {
            foreach(DBSpecification s in reader.getSpecsByProj(id))
            {
                deleter.delVerSpecBySpec(s.id);
                deleter.delSpec(s.id);
            }
            foreach(DBVersion v in reader.getVersionsByProj(id))
            {
                deleter.delVersion(v.id);
            }
            deleter.delProject(id);
        }

        public void deleteVersion(int id)
        {
            deleter.delVerSpecByVer(id);
            deleter.delVersion(id);
        }

        public void deleteSpec(int id)
        {
            deleter.delVerSpecBySpec(id);
            deleter.delSpec(id);
        }

        public void deleteEmployee(int id)
        {
            deleter.delTeamMemByEmp(id);
            deleter.delEmployee(id);
        }

        public void deleteTeam(int id)
        {
            deleter.delTeamMemByTeam(id);
            deleter.delTeam(id);
        }
    }
}
