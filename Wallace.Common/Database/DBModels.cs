using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallace.Common.Models;

namespace Wallace.Common.Database
{
    public class DBProject
    {
        public int id;
        public string name;
        public int budget;
        public string desc;
        public int? manager;

        public DBProject() { }

        public DBProject(Project p)
        {
            id = p.id;
            name = p.name;
            budget = p.budget;
            desc = p.desc;
            manager = p.manager.id;
        }
    }

    public class DBClient
    {
        public int id;
        public string name;
        public string company;
        public string contact;

        public DBClient()
        {

        }
    }

    public class DBEmployee
    {
        public int id;
        public int salary;
        public string title;
        public string name;

        public DBEmployee() { }

        public DBEmployee(Employee e)
        {
            id = e.id;
            salary = e.salary;
            title = e.title;
            name = e.name;
        }
    }

    public class DBExperience
    {
        public int id;
        public string name;
        public string desc;
        public int length;

        public DBExperience()
        {

        }
    }

    public class DBSpecification
    {
        public int id;
        public string name;
        public string desc;
        public int pid;

        public DBSpecification() { }

        public DBSpecification(Spec s)
        {
            id = s.id;
            name = s.name;
            desc = s.description;
            pid = s.pid;
        }
    }

    public class DBTeam
    {
        public int id;
        public string name;
        public string desc;
        public int leader;
        public DBTeam() { }


        public DBTeam(Team t)
        {
            id = t.id;
            name = t.name;
            desc = t.desc;
        }
    }

    public class DBVersion
    {
        public int id;
        public int vnum;
        public DateTime release;

        public DBVersion() { }

        public DBVersion(PVersion v)
        {
            id = v.id;
            vnum = v.versionNumber;
            release = v.releaseDate;
        }
    }
}
