using System;
using System.Collections.Generic;
using System.Text;

namespace Wallace.Common.Models
{
    public class Team
    {

        public List<Employee> members;
        public string name;
        public int id;

        public Team(List<Employee> _members, string _name, int _id)
        {
            members = new List<Employee>();
            members = _members;
            name = _name;
            id = _id;
        }

    }
}
