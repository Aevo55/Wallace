using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;
namespace Wallace.Common.Models
{
    public class Spec
    {

        public int id;
        public string name;
        public string description;
        int pid;

        public Spec(int _id, string _name, string _description, int _pid)
        {
            id = _id;
            name = _name;
            description = _description;
            pid = _pid;
        }

        public Spec() { }

        public Spec(DBSpecification s)
        {
            id = s.id;
            name = s.name;
            description = s.desc;
        }
    }
}
