using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallace.Common.Database.DBModels
{
    public class DBProject
    {
        public int pid;
        public string name;
        public int budget;
        public string desc;
        public int? manager;
        public DBProject(int _pid, string _name, int _budget, string _desc, int _manager)
        {
            pid = _pid;
            name = _name;
            budget = _budget;
            desc = _desc;
            manager = _manager;
        }
        public DBProject() { }
    }
}
