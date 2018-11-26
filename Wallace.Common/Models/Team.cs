using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;

namespace Wallace.Common.Models
{
    public class Team
    {

        public List<Employee> members;
        public string name;
        public int id;
        public string desc;
        public Employee leader;

        public Team(List<Employee> _members, string _name, int _id)
        {
            members = new List<Employee>();
            members = _members;
            name = _name;
            id = _id;
        }

        public Team() { }

        public Team(DBTeam t)
        {
            members = new List<Employee>();
            name = t.name;
            id = t.id;
            desc = t.desc;
            leader = new Employee((new DatabaseReader()).getEmployee(t.leader));
        }

        public void getMembers()
        {
            DatabaseReader reader = new DatabaseReader();
            members.Clear();
            foreach (DBEmployee e in reader.getEmpsByTeam(id))
            {
                members.Add(new Employee(e));
            }
        }
    }
}
