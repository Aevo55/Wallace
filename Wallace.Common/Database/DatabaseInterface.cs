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
        DatabaseWriter writer;
        DatabaseUpdater updater;
        public DatabaseInterface() {
            reader = new DatabaseReader();
            deleter = new DatabaseDeleter();
            writer = new DatabaseWriter();
            updater = new DatabaseUpdater();
        }

        /***************************************/

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
                    foreach(DBTeam t in reader.getTeamsByVersion(v.id))
                    {
                        _v.teams.Add(new Team(t));
                    }
                    _p.versions.Add(_v);
                }
                foreach(DBSpecification s in reader.getSpecsByProj(p.id))
                {
                    _p.specs.Add(new Spec(s));
                }
                _p.manager = new Employee(reader.getEmployee(p.manager));
                projects.Add(_p);
            }
            return projects;
        }

        public Project getProject(int pid)
        {
            DBProject temp = reader.getProject(pid);
            Project p = new Project(temp);
            foreach (DBVersion v in reader.getVersionsByProj(pid))
            {
                PVersion _v = new PVersion(v);
                foreach (DBSpecification s in reader.getSpecsByVer(v.id))
                {
                    _v.specs.Add(new Spec(s));
                }
                foreach (DBTeam t in reader.getTeamsByVersion(v.id))
                {
                    _v.teams.Add(new Team(t));
                }
                p.versions.Add(_v);
            }
            foreach (DBSpecification s in reader.getSpecsByProj(pid))
            {
                p.specs.Add(new Spec(s));
            }
            p.manager = new Employee(reader.getEmployee(temp.manager));
            return p;
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

        public Team getTeam(int tid)
        {
            Team t = new Team(reader.getTeam(tid));
            foreach (DBEmployee e in reader.getEmpsByTeam(tid))
            {
                t.members.Add(new Employee(e));
            }
            return t;
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

        public Employee getEmployee(int eid)
        {
            Employee e = new Employee(reader.getEmployee(eid));
            foreach (DBTeam t in reader.getTeamsByEmp(e.id))
            {
                e.teams.Add(new Team(t));
            }
            return e;
        }

        public List<PVersion> getVersionByProject(int pid)
        {
            List<PVersion> vers = new List<PVersion>();
            foreach(DBVersion v in reader.getVersionsByProj(pid))
            {
                PVersion _v = new PVersion(v);
                foreach(DBSpecification s in reader.getSpecsByVer(_v.id))
                {
                    _v.specs.Add(new Spec(s));
                }
                foreach(DBTeam t in reader.getTeamsByVersion(_v.id))
                {
                    _v.teams.Add(new Team(t));
                }
                vers.Add(_v);
            }
            return vers;
        }

        public PVersion getVersion(int vid)
        {
            PVersion v = new PVersion(reader.getVersion(vid));
            foreach (DBSpecification s in reader.getSpecsByVer(vid))
            {
                v.specs.Add(new Spec(s));
            }
            foreach (DBTeam t in reader.getTeamsByVersion(vid))
            {
                v.teams.Add(new Team(t));
            }
            return v;
        }

        public int getMaxVersionNum(int pid)
        {
            return reader.getMaxVersionNum(pid);
        }

        public List<Spec> getSpecsByProject(int pid)
        {
            List<Spec> specs = new List<Spec>();
            foreach (DBSpecification s in reader.getSpecsByProj(pid))
            {
                specs.Add(new Spec(s));
            }
            return specs;
        }

        public List<Spec> getSpecsByVersion(int vid)
        {
            List<Spec> specs = new List<Spec>();
            foreach (DBSpecification s in reader.getSpecsByVer(vid))
            {
                specs.Add(new Spec(s));
            }
            return specs;
        }

        public Spec getSpec(int sid)
        {
            return new Spec(reader.getSpec(sid));
        }

        public List<Spec> getUnmetSpecs(int vid, int pid)
        {
            List<Spec> specs = new List<Spec>();
            foreach (DBSpecification s in reader.getUnmetSpecs(vid, pid))
            {
                specs.Add(new Spec(s));
            }
            return specs;
        }

        public List<Team> getTeamsNotOnVer(int vid)
        {
            List<Team> teams = new List<Team>();
            foreach (DBTeam t in reader.getTeamsNotOnVer(vid))
            {
                teams.Add(new Team(t));
            }
            return teams;
        }

        public List<Employee> searchEmployees(string query)
        {
            List<Employee> emps = new List<Employee>();
            foreach(DBEmployee e in reader.searchEmployees(query))
            {
                emps.Add(new Employee(e));
            }
            return emps;
        }

        public List<Employee> getEmployeesNotOnTeam(int tid)
        {
            List<Employee> emps = new List<Employee>();
            foreach(DBEmployee e in reader.getEmpsNotOnTeam(tid))
            {
                emps.Add(new Employee(e));
            }
            return emps;
        }
        /***************************************/

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
            deleter.delVerTeamByVer(id);
            deleter.delVersion(id);
        }

        public void deleteSpec(int id)
        {
            deleter.delVerSpecBySpec(id);
            deleter.delSpec(id);
        }

        public void deleteSpecFromVersion(int sid, int vid)
        {
            deleter.delVerSpecByBoth(vid, sid);
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

        public void deleteEmployeeFromTeam(int tid, int eid)
        {
            deleter.delTeamMemByBoth(tid, eid);

        }

        public void deleteTeamFromVersion(int tid, int vid)
        {
            deleter.delVerTeamByBoth(tid, vid);
        }

        /***************************************/

        public int addProject(Project p)
        {
            return writer.addProject(new DBProject(p));
        }

        public int addVersion(PVersion v)
        {
            return writer.addVersion(new DBVersion(v));
        }

        public int addSpecToProject(Spec s)
        {
            return writer.addSpec(new DBSpecification(s));
        }

        public void addSpecToVersion(PVersion v, Spec s)
        {
            writer.addVersionSpec(v.id, s.id);
        }
        
        public int addTeam(Team t)
        {
            return writer.addTeam(new DBTeam(t));
        }

        public int addEmployee(Employee e)
        {
            return writer.addEmployee(new DBEmployee(e));
        }

        public void addEmpToTeam(Employee e, Team t)
        {
            writer.addTeamMem(e.id, t.id);
        }

        public void addTeamToVersion(Team t, PVersion v)
        {
            writer.addVersionTeam(t.id, v.id);
        }

        /***************************************/

        public void updateEmployee(Employee e)
        {
            updater.updateEmployee(new DBEmployee(e));
        }

        public void updateProject(Project p)
        {
            updater.updateProject(new DBProject(p));
        }

        public void updateSpecification(Spec s)
        {
            updater.updateSpecification(new DBSpecification(s));
        }

        public void updateTeam(Team t)
        {
            updater.updateTeam(new DBTeam(t));
        }

        public void updateVersion(PVersion v)
        {
            updater.updateVersion(new DBVersion(v));
        }
    }
}
