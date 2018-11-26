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
        public int manager;
    }

    public class DBClient
    {
        public int id;
        public string name;
        public string company;
        public string contact;
    }

    public class DBEmployee
    {
        public int id;
        public int salary;
        public string title;
        public string name;
    }

    public class DBExperience
    {
        public int id;
        public string name;
        public string desc;
        public int length;
    }

    public class DBSpecification
    {
        public int id;
        public string name;
        public string desc;
        public int pid;
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
    }
}
